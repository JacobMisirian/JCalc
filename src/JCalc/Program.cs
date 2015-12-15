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
            JCalcEngine engine = new JCalcEngine();
            if (args.Length <= 0)
                engine.ExecuteREPL("\n>>> ");
            else
                try
                {
                    engine.ExecuteSource(File.ReadAllText(args[0]));
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File " + args[0] + " was not found!");
                }
        }
    }
}
