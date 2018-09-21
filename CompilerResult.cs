using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LLVMSharp;

namespace Compiler
{
    partial class CompilerResult
    {

    }
    class NullCompilerResult : CompilerResult
    {
        public static NullCompilerResult INSTANCE = new NullCompilerResult();

        private NullCompilerResult()
        {

        }
    }
    class Int32CompilerResult : CompilerResult
    {
        public LLVMSharp.LLVMValueRef reference;

        public Int32CompilerResult(LLVMValueRef reference)
        {
            this.reference = reference;
        }
    }
}
