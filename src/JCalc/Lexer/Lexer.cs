using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCalc.Lexer
{
    public class Lexer
    {
        private int position = 0;
        private string code = "";
        private List<Token> result = new List<Token>();

        private string peekLetter { get { return ((char)peekChar()).ToString(); } }
        private string readLetter { get { return ((char)readChar()).ToString(); } }

        public Lexer(string source)
        {
            code = source;
        }

        public List<Token> Scan()
        {
            whiteSpace();
            while (peekChar() != -1)
            {
                if (char.IsLetterOrDigit((char)peekChar()))
                    result.Add(scanData());
                else
                    switch (peekLetter)
                    {
                        case "\"":
                            result.Add(scanString());
                            break;
                        case "-":
                            readChar();
                            if (peekLetter == ">")
                                result.Add(new Token(TokenType.Assignment, "-" + readLetter));
                            else
                                result.Add(new Token(TokenType.Operation, "-"));
                            break;
                        case "+":
                        case "*":
                        case "/":
                        case "%":
                            result.Add(new Token(TokenType.Operation, readLetter));
                            break;
                        case "(":
                        case ")":
                            result.Add(new Token(TokenType.Parentheses, readLetter));
                            break;
                        default:
                            Console.WriteLine("Unknown token " + readLetter);
                            break;
                    }
                whiteSpace();
            }
            return result;
        }

        private Token scanString()
        {
            string res = "";
            readChar();
            while (peekChar() != -1 && peekLetter != "\"")
                res += readLetter;
            return new Token(TokenType.String, res);
        }

        private Token scanData()
        {
            string result = "";
            double temp = 0;
            while ((char.IsLetterOrDigit((char)peekChar()) && peekChar() != -1) || ((char)(peekChar()) == '.'))
                result += ((char)readChar()).ToString();
            if (double.TryParse(result, out temp))
                return new Token(TokenType.Number, result);

            return new Token(TokenType.Identifier, result);
        }


        private void whiteSpace()
        {
            while (peekChar() != -1 && char.IsWhiteSpace((char)peekChar()))
                readChar();
        }

        private int peekChar(int n = 0)
        {
            if (position < code.Length)
                return code[position];
            return -1;
        }

        private int readChar()
        {
            if (position < code.Length)
                return code[position++];
            return -1;
        }
    }
}
