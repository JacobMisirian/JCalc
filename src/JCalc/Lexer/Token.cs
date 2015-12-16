using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCalc.Lexer
{
    public enum TokenType
    {
        Identifier,
        String,
        Number,
        Operation,
        Comparison,
        Assignment,
        Parentheses,
        Comma,
        Brace
    }

    public class Token
    {
        public TokenType TokenType { get; private set; }
        public string Value { get; private set; }

        public Token(TokenType tokenType, string value)
        {
            TokenType = tokenType;
            Value = value;
        }
    }
}
