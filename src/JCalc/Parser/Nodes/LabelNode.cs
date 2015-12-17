using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JCalc.Lexer;

namespace JCalc.Parser.Nodes
{
    public class LabelNode: AstNode
    {
        public string Identifier { get; private set; }

        public LabelNode(string identifier)
        {
            Identifier = identifier;
        }

        public static LabelNode Parse(Parser parser)
        {
            string identifier = parser.ExpectToken(TokenType.Identifier).Value;

            return new LabelNode(identifier);
        }
    }
}
