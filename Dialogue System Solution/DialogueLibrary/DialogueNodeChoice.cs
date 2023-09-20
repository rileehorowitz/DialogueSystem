using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueLibrary
{
    public class DialogueChoice
    {
        private string choicePreview;
        private DialogueNode choiceNode;

        public DialogueChoice(string choicePreview, DialogueNode choiceNode)
        {
            this.choicePreview = choicePreview;
            NextNode = choiceNode;
        }

        public DialogueNode NextNode
        {
            get
            {
                return choiceNode;
            }
            set
            {
                choiceNode = value;
            }
        }
    }
    public class DialogueNodeChoice : DialogueNode
    {
        private DialogueChoice[] choices;
        public DialogueNodeChoice(DialogueChoice[] choices, Text text)
            : base(text)
        {
            this.choices = choices;
        }

        //When attempting to move to a new node, check if the new node is our current node's next node
        public override bool CanBeFollowedByNode(DialogueNode node)
        {
            //if the array of choices contains the passed in node, return true
            return choices.Any(x => x.NextNode == node);
        }
    }
}
