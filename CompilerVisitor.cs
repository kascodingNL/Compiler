using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using LLVMSharp;
using Parser;

namespace Compiler
{
    class CompilerVisitor : LangBaseVisitor<CompilerResult>
    {
        private LLVMModuleRef module;
        private LLVMValueRef method;
        private LLVMBuilderRef builder;
        private Stack<Context> contexts;
        private LLVMPassManagerRef passManager;

        public override CompilerResult VisitFile([NotNull] LangParser.FileContext context)
        {
            module = LLVM.ModuleCreateWithName("Lang");
            contexts = new Stack<Context>();

            LLVMPassManagerRef passManager = LLVM.CreateFunctionPassManagerForModule(module);

            // Set up the optimizer pipeline.  Start with registering info about how the
            // target lays out data structures.
            // LLVM.DisposeTargetData(LLVM.GetExecutionEngineTargetData(engine));

            // Provide basic AliasAnalysis support for GVN.
            LLVM.AddBasicAliasAnalysisPass(passManager);

            // Promote allocas to registers.
            LLVM.AddPromoteMemoryToRegisterPass(passManager);

            // Do simple "peephole" optimizations and bit-twiddling optzns.
            LLVM.AddInstructionCombiningPass(passManager);

            // Reassociate expressions.
            LLVM.AddReassociatePass(passManager);

            // Eliminate Common SubExpressions.
            LLVM.AddGVNPass(passManager);

            // Simplify the control flow graph (deleting unreachable blocks, etc).
            LLVM.AddCFGSimplificationPass(passManager);

            LLVM.InitializeFunctionPassManager(passManager);
            this.passManager = passManager;

            base.VisitFile(context);



            LLVM.VerifyModule(module, LLVMVerifierFailureAction.LLVMPrintMessageAction, out string str);

            LLVM.DumpModule(module);

            LLVM.WriteBitcodeToFile(module, @"C:\Users\superblaubeere27\Desktop\compilerTest\Compiler\Compiler\code\compiled.bc");

            LLVM.DisposePassManager(passManager);
            LLVM.DisposeModule(module);


            return NullCompilerResult.INSTANCE;
        }

        public override CompilerResult VisitMethod([NotNull] LangParser.MethodContext context)
        {
            var @params = context.parameter_declaration().NAME();
            LLVMTypeRef[] paramTypes = new LLVMTypeRef[@params.Count()];

            for (int i = 0; i < @params.Count(); i++)
            {
                paramTypes[i] = LLVM.Int32Type();
            }

            method = LLVM.AddFunction(module, context.NAME().GetText(), LLVM.FunctionType(LLVM.Int32Type(), paramTypes, false));
            LLVMBasicBlockRef entryBlock = LLVM.AppendBasicBlock(method, "entry");
            builder = LLVM.CreateBuilder();
            LLVM.PositionBuilderAtEnd(builder, entryBlock);

            PushContext();

            for (uint i = 0; i < @params.Count(); i++)
            {
                CurrContext().registerParameter(method, @params[i].GetText(), i);
            }

            base.VisitMethod(context);

            LLVM.RunFunctionPassManager(passManager, method);

            PopContext();

            LLVM.DisposeBuilder(builder);


            return NullCompilerResult.INSTANCE;
        }

        private Context CurrContext()
        {
            return contexts.Peek();
        }

        private void PopContext()
        {
            contexts.Pop();
        }

        private void PushContext()
        {
            contexts.Push(new Context(contexts.Count > 0 ? contexts.Peek() : null));
        }

        public override CompilerResult VisitBlock([NotNull] LangParser.BlockContext context)
        {
            PushContext();

            base.VisitBlock(context);

            PopContext();

            return NullCompilerResult.INSTANCE;
        }

        public override CompilerResult VisitExpression([NotNull] LangParser.ExpressionContext context)
        {

            if (context.NAME() != null)
            {
                string name = context.NAME().GetText();
                
                Parameter parameter = CurrContext().lookupParameter(name);
                LLVMValueRef? @ref = null;

                if (parameter != null)
                {
                    @ref = parameter.Load();
                } else
                {
                    LocalVariable lv = CurrContext().lookupLocalVar(name);

                    if (lv != null)
                    {
                        @ref = lv.Load(builder);
                    }
                }


                if (!@ref.HasValue)
                {
                    throw new Exception("Lookup failed " + name);
                }

                return new Int32CompilerResult(@ref.Value);
            }

            if (context.NUMBER() != null)
            {
                return new Int32CompilerResult(LLVM.ConstInt(LLVM.Int32Type(), UInt32.Parse(context.NUMBER().GetText()), true));
            }

            if (context.ChildCount == 3)
            {
                Int32CompilerResult lhs = (Int32CompilerResult) VisitExpression(context.expression()[0]);
                Int32CompilerResult rhs = (Int32CompilerResult) VisitExpression(context.expression()[1]);

                if (context.MULTIPLY() != null)
                {
                    return new Int32CompilerResult(LLVM.BuildMul(builder, lhs.reference, rhs.reference, "multmp"));
                }
                if (context.DIVIDE() != null)
                {
                    return new Int32CompilerResult(LLVM.BuildSDiv(builder, lhs.reference, rhs.reference, "divtmp"));
                }
                if (context.MODULO() != null)
                {
                    return new Int32CompilerResult(LLVM.BuildSRem(builder, lhs.reference, rhs.reference, "remtmp"));
                }
                if (context.ADD() != null)
                {
                    return new Int32CompilerResult(LLVM.BuildAdd(builder, lhs.reference, rhs.reference, "addtmp"));
                }
                if (context.SUBSTRACT() != null)
                {
                    return new Int32CompilerResult(LLVM.BuildSub(builder, lhs.reference, rhs.reference, "subtmp"));
                }
            }

            return base.VisitExpression(context);
        }
        

        public override CompilerResult VisitParaphrase([NotNull] LangParser.ParaphraseContext context)
        {
            return VisitExpression(context.expression());
        }

        public override CompilerResult VisitReturn_statement([NotNull] LangParser.Return_statementContext context)
        {
            LLVM.BuildRet(builder, ((Int32CompilerResult)VisitExpression(context.expression())).reference);
            return NullCompilerResult.INSTANCE;
        }

        public override CompilerResult VisitVar_declaration([NotNull] LangParser.Var_declarationContext context)
        {
            LocalVariable lv = CurrContext().registerLocalVariable(builder, method, context.NAME().GetText());

            if (context.expression() != null)
            {
                lv.Assign(builder, (Int32CompilerResult) VisitExpression(context.expression()));
            }

            return NullCompilerResult.INSTANCE;
        }

        public override CompilerResult VisitAssignment([NotNull] LangParser.AssignmentContext context)
        {
            LocalVariable lv = CurrContext().lookupLocalVar(context.NAME().GetText());

            if (lv == null)
            {
                throw new Exception("Lookup failed: " + context.NAME().GetText());
            }
            

            return new Int32CompilerResult(lv.Assign(builder, (Int32CompilerResult)VisitExpression(context.expression())));
        }
    }
}
