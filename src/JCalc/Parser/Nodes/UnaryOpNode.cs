using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCalc.Parser.Nodes
{
    public enum UnaryOperation
    {
        Not
    }

    public class UnaryOpNode: AstNode
    {
        public AstNode Target { get { return Children[0]; } }
        public UnaryOperation UnaryOperation { get; private set; }

        public UnaryOpNode(UnaryOperation unaryOperation, AstNode target)
        {
            Children.Add(target);
            UnaryOperation = unaryOperation;
        }
    }
}
