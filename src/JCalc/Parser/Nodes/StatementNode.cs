using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JCalc.Lexer;

namespace JCalc.Parser.Nodes
{
    public class StatementNode: AstNode
    {
        public static AstNode Parse(Parser parser)
        {
            return ExpressionNode.Parse(parser);
        }
    }
}
