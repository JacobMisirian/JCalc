using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JCalc.Lexer;

namespace JCalc.Parser.Nodes
{
    public class ForNode: AstNode
    {
        public AstNode FirstStatement { get { return Children[0]; } }
        public AstNode Predicate { get { return Children[1]; } }
        public AstNode RepeatStatement { get { return Children[2]; } }
        public AstNode Body { get { return Children[3]; } }

        public ForNode(AstNode firstStatement, AstNode predicate, AstNode repeatStatement, AstNode body)
        {
            Children.Add(firstStatement);
            Children.Add(predicate);
            Children.Add(repeatStatement);
            Children.Add(body);
        }

        public static ForNode Parse(Parser parser)
        {
            AstNode firstStatement = StatementNode.Parse(parser);
            parser.ExpectToken(TokenType.Comma);
            AstNode predicate = ExpressionNode.Parse(parser);
            parser.ExpectToken(TokenType.Comma);
            AstNode repeatStatement = StatementNode.Parse(parser);
            AstNode body = StatementNode.Parse(parser);

            return new ForNode(firstStatement, predicate, repeatStatement, body);
        }
    }
}
