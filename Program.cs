using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Antlr4.Runtime;
using Parser;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader fileStream = new StreamReader(@"C:\Users\superblaubeere27\Desktop\compilerTest\Compiler\Compiler\test.lang"))
            {
                AntlrInputStream inputStream = new AntlrInputStream(fileStream);

                LangLexer lexer = new LangLexer(inputStream);
                CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
                LangParser parser = new LangParser(commonTokenStream);

                new CompilerVisitor().VisitFile(parser.file());
            }
        }
    }
}
