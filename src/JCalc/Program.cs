using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JCalc.Lexer;

namespace JCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Interpreter.Interpreter interpreter = new Interpreter.Interpreter();

            if (args.Length <= 0)
                while (true)
                {
                    string input = Console.ReadLine();
                    interpreter.Execute(new Parser.Parser(new Lexer.Lexer(input).Scan()).Parse());
                }
            else
                interpreter.Execute(new Parser.Parser(new Lexer.Lexer(File.ReadAllText(args[0])).Scan()).Parse());
        }
    }
}
