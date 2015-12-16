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
            if (parser.AcceptToken(TokenType.Identifier, "If"))
                return IfNode.Parse(parser);
            else if (parser.AcceptToken(TokenType.Identifier, "Disp"))
                return new DispNode(ArgListNode.Parse(parser));
            else if (parser.AcceptToken(TokenType.Identifier, "Input"))
                return new InputNode(ArgListNode.Parse(parser));
            else if (parser.AcceptToken(TokenType.Identifier, "Prompt"))
                return new PromptNode(ArgListNode.Parse(parser));
            else if (parser.AcceptToken(TokenType.Identifier, "Stop"))
                return new StopNode();
            else
                return ExpressionNode.Parse(parser);
        }
    }
}
