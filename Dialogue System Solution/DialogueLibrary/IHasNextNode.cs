using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueLibrary
{
    public interface IHasNextNode
    {
        public DialogueNode NextNode { get; set; }
        public int NextNodeIndex { get; set; }
    }
}
