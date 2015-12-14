using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCalc.Interpreter.Functions
{
    public class StandardLibrary : ILibrary
    {
        private static Random rand = new Random();

        public Dictionary<string, InternalFunction> GetFunctions()
        {
            var result = new Dictionary<string, InternalFunction>();

            result.Add("Abs", new InternalFunction(Abs));
            result.Add("ATan", new InternalFunction(ATan));
            result.Add("Cos", new InternalFunction(Cos));
            result.Add("Exp", new InternalFunction(Exp));
            result.Add("Log", new InternalFunction(Log));
            result.Add("Rand", new InternalFunction(Rand));
            result.Add("Sin", new InternalFunction(Sin));
            result.Add("Sqrt", new InternalFunction(Sqrt));

            return result;
        }

        private static object Abs(object[] args)
        {
            return Convert.ToDouble(Math.Abs(Convert.ToDouble(args[0])));
        }

        private static object ATan(object[] args)
        {
            return Math.Atan(Convert.ToDouble(args[0]));
        }

        private static object Cos(object[] args)
        {
            return Math.Cos(Convert.ToDouble(args[0]));
        }

        private static object Exp(object[] args)
        {
            return Math.Exp(Convert.ToDouble(args[0]));
        }

        private static object Log(object[] args)
        {
            return Math.Log(Convert.ToDouble(args[0]));
        }

        private static object Rand(object[] args)
        {
            if (args.Length <= 0)
                return Convert.ToDouble(rand.Next());
            else if (args.Length == 1)
                return Convert.ToDouble(rand.Next(Convert.ToInt32(args[0])));
            else
                return Convert.ToDouble(rand.Next(Convert.ToInt32(args[0]), Convert.ToInt32(args[1])));
        }

        private static object Sin(object[] args)
        {
            return Math.Sin(Convert.ToDouble(args[0]));
        }

        private static object Sqrt(object[] args)
        {
            return Math.Sqrt(Convert.ToDouble(args[0]));
        }
    }
}
