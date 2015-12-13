using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCalc.Parser.Nodes
{
    public class NumberNode: AstNode
    {
        public double Number { get; private set; }

        public NumberNode(double number)
        {
            Number = number;
        }
    }
}
