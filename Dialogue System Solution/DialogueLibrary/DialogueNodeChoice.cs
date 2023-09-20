using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DialogueLibrary
{
    public class DialogueNodeChoice : DialogueNode
    {
        private DialogueChoice[] choices;
        public DialogueNodeChoice(DialogueChoice[] choices, Text text)
            : base(text)
        {
            this.choices = choices;
        }

        //Read Only public property to access choices
        public DialogueChoice[] Choices
        {
            get => choices;
        }

        //Read Only public property to access nextNode
        public override DialogueNode NextNode
        {
            get;
        }


        //When attempting to move to a new node, check if the new node is our current node's next node
        public override bool CanBeFollowedByNode(DialogueNode node)
        {
            //if the array of choices contains the passed in node, return true
            return choices.Any(x => x.NextNode == node);
        }
        public override string ToString()
        {
            string output = $"{Text}";
            foreach (DialogueChoice choice in Choices)
            {
                output += $"\n{choice}";
            }
            return output;
        }
        public override DialogueNode GetNextNode()
        {
            //logic to determine which choice has been chosen
            return NextNode;
        }
    }
}
