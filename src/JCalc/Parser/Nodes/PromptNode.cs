using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCalc.Parser.Nodes
{
    public class PromptNode: AstNode
    {
        public ArgListNode Contents { get { return (ArgListNode)Children[0]; } }

        public PromptNode(ArgListNode contents)
        {
            Children.Add(contents);
        }
    }
}
