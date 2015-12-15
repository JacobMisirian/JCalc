using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCalc
{
    public class JCalcEngine
    {
        private string source { get; set; }
        private Interpreter.Interpreter interpreter { get; set; }

        public JCalcEngine()
        {
            interpreter = new Interpreter.Interpreter();
        }

        public JCalcEngine(string source)
        {
            interpreter = new Interpreter.Interpreter(new Parser.Parser(new Lexer.Lexer(source).Scan()).Parse());
            this.source = source;
        }

        public void ExecuteSource(string source = "")
        {
            this.source = (source == "") ? this.source : source;
            if (this.source == "")
                throw new Exception("Source code must be set in constructor or in ExecuteSource()");
            interpreter.Execute(new Parser.Parser(new Lexer.Lexer(this.source).Scan()).Parse());
        }

        public void ExecuteREPL(string prompt = "")
        {
            while (true)
            {
                Console.Write(prompt);
                interpreter.Execute(new Parser.Parser(new Lexer.Lexer(Console.ReadLine()).Scan()).Parse());
            }
        }
    }
}
