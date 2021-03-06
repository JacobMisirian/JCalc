﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCalc.Parser.Nodes
{
    public class WhileNode: AstNode
    {
        public AstNode Predicate { get { return Children[0]; } }
        public AstNode Body { get { return Children[1]; } }

        public WhileNode(AstNode predicate, AstNode body)
        {
            Children.Add(predicate);
            Children.Add(body);
        }

        public static WhileNode Parse(Parser parser)
        {
            AstNode predicate = ExpressionNode.Parse(parser);
            AstNode body = StatementNode.Parse(parser);

            return new WhileNode(predicate, body);
        }
    }
}
