using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using JCalc.Parser;
using JCalc.Parser.Nodes;

namespace JCalc.Interpreter
{
    public class Interpreter
    {
        private int position = 0;
        private AstNode code { get; set; }
        private Stack stack = new Stack();
        public Dictionary<string, object> Variables = new Dictionary<string, object>()
        {
            {"True", true },
            {"False", false },
            {"Pi", Math.PI }
        };

        public Interpreter(AstNode ast = null)
        {
            code = ast;
            foreach (Dictionary<string, InternalFunction> entries in getFunctions())
                foreach (KeyValuePair<string, InternalFunction> entry in entries)
                    Variables.Add(entry.Key, entry.Value);
        }

        public void Execute(AstNode ast = null, bool displayLastCalculation = true)
        {
            code = (ast == null) ? code : ast;
            for (position = 0; position < code.Children.Count; position++)
                executeStatement(code.Children[position]);

            if (displayLastCalculation)
                try
                {
                    Console.WriteLine(stack.Peek());
                }
                catch
                { }
        }

        private void executeStatement(AstNode node)
        {
            if (node is CodeBlockNode)
                foreach (AstNode cnode in node.Children)
                    executeStatement(cnode);
            else
                evaluateNode(node);
        }

        private object evaluateNode(AstNode node)
        {
            if (node is IdentifierNode)
            {
                IdentifierNode idNode = (IdentifierNode)node;
                if (Variables.ContainsKey(idNode.Identifier))
                    return Variables[idNode.Identifier];
                throw new Exception("Variable " + idNode.Identifier + " does not exist in dictionary!");
            }
            else if (node is NumberNode)
                return ((NumberNode)node).Number;
            else if (node is StringNode)
                return ((StringNode)node).Value;
            else if (node is BinaryOpNode)
            {
                var ret = interpretBinaryOperation((BinaryOpNode)node);
                stack.Push(ret);
                return ret;
            }
            else if (node is UnaryOpNode)
            {
                var ret = interpretUnaryOperation((UnaryOpNode)node);
                stack.Push(ret);
                return ret;
            }
            else if (node is FunctionCallNode)
            {
                FunctionCallNode fnode = (FunctionCallNode)node;
                IFunction target = evaluateNode(fnode.Target) as IFunction;
                if (target == null)
                    throw new Exception("Attempt to run a non-valid function!");
                object[] arguments = new object[fnode.Arguments.Children.Count];
                for (int x = 0; x < fnode.Arguments.Children.Count; x++)
                    arguments[x] = evaluateNode(fnode.Arguments.Children[x]);
                var ret = target.Invoke(arguments);
                stack.Push(ret);
                return ret;
            }
            else
                throw new Exception("Unknown node " + node.ToString() + "  " + node.GetType());
        }

        private object interpretBinaryOperation(BinaryOpNode node)
        {
            switch (node.BinaryOperation)
            {
                case BinaryOperation.Assignment:
                    if (!(node.Right is IdentifierNode))
                        throw new Exception("Must be an identifier!");
                    string key = ((IdentifierNode)node.Right).Identifier;
                    object value = evaluateNode(node.Left);

                    if (Variables.ContainsKey(key))
                        Variables.Remove(key);
                    Variables.Add(key, value);

                    return value;
                case BinaryOperation.Addition:
                    object addLeft = evaluateNode(node.Left);
                    object addRight = evaluateNode(node.Right);
                    if (addLeft is string || addRight is string)
                        return (string)addLeft + (string)addRight;
                    else
                        return Convert.ToDouble(addLeft) + Convert.ToDouble(addRight);
                case BinaryOperation.Subtraction:
                    return Convert.ToDouble(evaluateNode(node.Left)) - Convert.ToDouble(evaluateNode(node.Right));
                case BinaryOperation.Division:
                    return Convert.ToDouble(evaluateNode(node.Left)) / Convert.ToDouble(evaluateNode(node.Right));
                case BinaryOperation.Multiplication:
                    return Convert.ToDouble(evaluateNode(node.Left)) * Convert.ToDouble(evaluateNode(node.Right));
                case BinaryOperation.Modulus:
                    return Convert.ToDouble(evaluateNode(node.Left)) % Convert.ToDouble(evaluateNode(node.Right));
                case BinaryOperation.Equals:
                    return evaluateNode(node.Left).GetHashCode() == evaluateNode(node.Right).GetHashCode();
                case BinaryOperation.Not:
                    return evaluateNode(node.Left).GetHashCode() != evaluateNode(node.Right).GetHashCode();
                case BinaryOperation.LessThan:
                    return Convert.ToDouble(evaluateNode(node.Left)) < Convert.ToDouble(evaluateNode(node.Right));
                case BinaryOperation.GreaterThan:
                    return Convert.ToDouble(evaluateNode(node.Left)) > Convert.ToDouble(evaluateNode(node.Right));
                case BinaryOperation.GreaterThanOrEqual:
                    return Convert.ToDouble(evaluateNode(node.Left)) >= Convert.ToDouble(evaluateNode(node.Right));
                case BinaryOperation.LesserThanOrEqual:
                    return Convert.ToDouble(evaluateNode(node.Left)) <= Convert.ToDouble(evaluateNode(node.Right));
                default:
                    throw new Exception("Unknown binary operation " + node.BinaryOperation);
            }
        }

        private object interpretUnaryOperation(UnaryOpNode node)
        {
            switch (node.UnaryOperation)
            {
                case UnaryOperation.Not:
                    return !(Convert.ToBoolean(evaluateNode(node.Target)));
                default:
                    throw new Exception("Unknown unary operation " + node.UnaryOperation);
            }
        }

        private List<Dictionary<string, InternalFunction>> getFunctions(string path = "")
        {
            List<Dictionary<string, InternalFunction>> result = new List<Dictionary<string, InternalFunction>>();
            Assembly testAss;

            if (path != "")
                testAss = Assembly.LoadFrom(path);
            else
                testAss = Assembly.GetExecutingAssembly();

            foreach (Type type in testAss.GetTypes())
                if (type.GetInterface(typeof(ILibrary).FullName) != null)
                {
                    ILibrary ilib = (ILibrary)Activator.CreateInstance(type);
                    result.Add(ilib.GetFunctions());
                }

            return result;
        }
    }
}