using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCalc.Parser.Nodes
{
    public enum BinaryOperation
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Modulus,
        Assignment,
        Equals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LesserThanOrEqual,
        Not
    }

    public class BinaryOpNode: AstNode
    {
        public AstNode Left { get { return Children[0]; } }
        public AstNode Right { get { return Children[1]; } }
        public BinaryOperation BinaryOperation { get; private set; }

        public BinaryOpNode(BinaryOperation binaryOperation, AstNode left, AstNode right)
        {
            Children.Add(left);
            Children.Add(right);
            BinaryOperation = binaryOperation;
        }
    }
}
