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
        private string[] parameterNames;
        private LLVMBuilderRef builder;

        public override CompilerResult VisitFile([NotNull] LangParser.FileContext context)
        {
            module = LLVM.ModuleCreateWithName("Lang");

            base.VisitFile(context);


            LLVM.VerifyModule(module, LLVMVerifierFailureAction.LLVMPrintMessageAction, out string str);

            LLVM.DumpModule(module);

            LLVM.WriteBitcodeToFile(module, @"C:\Users\superblaubeere27\Desktop\compilerTest\Compiler\Compiler\code\compiled.bc");


            return new NullCompilerResult();
        }

        public override CompilerResult VisitMethod([NotNull] LangParser.MethodContext context)
        {
            var @params = context.parameter_declaration().NAME();
            parameterNames = new string[@params.Count()];
            LLVMTypeRef[] paramTypes = new LLVMTypeRef[@params.Count()];

            for (int i = 0; i < @params.Count(); i++)
            {
                parameterNames[i] = @params[i].GetText();
                paramTypes[i] = LLVM.Int32Type();
            }

            method = LLVM.AddFunction(module, context.NAME().GetText(), LLVM.FunctionType(LLVM.Int32Type(), paramTypes, false));
            LLVMBasicBlockRef entryBlock = LLVM.AppendBasicBlock(method, "entry");
            builder = LLVM.CreateBuilder();
            LLVM.PositionBuilderAtEnd(builder, entryBlock);

            base.VisitMethod(context);


            return new NullCompilerResult();
        }

        public override CompilerResult VisitBlock([NotNull] LangParser.BlockContext context)
        {
            return base.VisitBlock(context);
        }

        public override CompilerResult VisitExpression([NotNull] LangParser.ExpressionContext context)
        {

            if (context.NAME() != null)
            {
                string name = context.NAME().GetText();
                int parameterIndex = -1;

                for (int i = 0; i < parameterNames.Count(); i++)
                {
                    if (parameterNames[i].Equals(name))
                    {
                        parameterIndex = i;
                    }
                }


                if (parameterIndex == -1)
                {
                    throw new Exception("There is no parameter with name " + name);
                }

                return new Int32CompilerResult(LLVM.GetParam(method, (uint) parameterIndex));
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
            return new NullCompilerResult();
        }
    }
}
