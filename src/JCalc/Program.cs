using System;
using System.Collections.Generic;
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
            while (true)
            {
                string input = Console.ReadLine();
                interpreter.Execute(new Parser.Parser(new Lexer.Lexer(input).Scan()).Parse());
            }
        }
    }
}
