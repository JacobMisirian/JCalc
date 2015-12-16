using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JCalc.Lexer;

namespace JCalc.Parser.Nodes
{
    public class IfNode: AstNode
    {
        public AstNode Predicate { get { return Children[0]; } }
        public AstNode Body { get { return Children[1]; } }
        public AstNode ElseBody { get { return Children[2]; } }

        public IfNode(AstNode predicate, AstNode body, AstNode elseBody = null)
        {
            Children.Add(predicate);
            Children.Add(body);
            if (elseBody != null)
                Children.Add(elseBody);
        }

        public static IfNode Parse(Parser parser)
        {
            AstNode predicate = ExpressionNode.Parse(parser);
            AstNode body = StatementNode.Parse(parser);
            AstNode elseBody = null;
            if (parser.MatchToken(TokenType.Identifier, "Else"))
            {
                parser.ExpectToken(TokenType.Identifier);
                elseBody = StatementNode.Parse(parser);
            }

            return new IfNode(predicate, body, elseBody);
        }
    }
}
