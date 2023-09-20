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
            NextNode = nextNode;
        }
        //setting the public property of DialogueNodeBasic called NextNode 
        public DialogueNode NextNode
        {
            get
            {
                return nextNode;
            }
            set
            {
                nextNode = value;
            }
        }

        //When attempting to move to a new node, check if the new node is our current node's next node
        public override bool CanBeFollowedByNode(DialogueNode node)
        {
            return nextNode == node;
        }
    }
}
