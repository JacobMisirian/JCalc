using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCalc.Parser.Nodes
{
    public class DispNode: AstNode
    {
        public ArgListNode Content { get { return (ArgListNode)Children[0]; } }

        public DispNode(ArgListNode content)
        {
            Children.Add(content);
        }
    }
}
