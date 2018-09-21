using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LLVMSharp;

namespace Compiler
{
    class Parameter
    {
        public string name;
        public LLVMValueRef method;
        public uint index;

        public Parameter(string name, LLVMValueRef method, uint index)
        {
            this.name = name;
            this.method = method;
            this.index = index;
        }

        public LLVMValueRef Load()
        {
            return LLVM.GetParam(method, index);
        }
    }
}
