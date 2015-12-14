using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JCalc.Lexer;

namespace JCalc.Parser.Nodes
{
    public class ArgListNode : AstNode
    {
        public static ArgListNode Parse(Parser parser)
        {
            ArgListNode ret = new ArgListNode();

            while (true)
            {
                ret.Children.Add(ExpressionNode.Parse(parser));
                if (!parser.AcceptToken(TokenType.Comma))
                    break;
            }

            return ret;
        }
    }
}
