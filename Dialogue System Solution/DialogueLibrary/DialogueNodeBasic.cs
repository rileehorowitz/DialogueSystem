using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueLibrary
{
    public class DialogueNodeBasic : DialogueNode
    {
        private DialogueNode nextNode;

        public DialogueNodeBasic(DialogueNode nextNode, Text text)
            : base(text)
        {
            this.nextNode = nextNode;
        }

        //Read Only public property to access nextNode
        public override DialogueNode NextNode
        {
            get => nextNode;
        }

        //When attempting to move to a new node, check if the new node is our current node's next node
        public override bool CanBeFollowedByNode(DialogueNode node)
        {
            return nextNode == node;
        }

        public override DialogueNode GetNextNode()
        {
            return NextNode;
        }
    }
}
