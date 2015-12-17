using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JCalc.Lexer;

namespace JCalc.Parser.Nodes
{
    public class GotoNode: AstNode
    {
        public string Identifier { get; private set; }

        public GotoNode(string identifier)
        {
            Identifier = identifier;
        }

        public static GotoNode Parse(Parser parser)
        {
            string identifier = parser.ExpectToken(TokenType.Identifier).Value;

            return new GotoNode(identifier);
        }
    }
}
