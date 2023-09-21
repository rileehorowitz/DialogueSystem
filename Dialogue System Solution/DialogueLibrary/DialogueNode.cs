using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueLibrary
{
    public abstract class DialogueNode
    {
        private Text text;
        private DialogueNode? nextNode;
        //Read Only public property to access text and nextNode
        public Text Text { get => text; }
        public abstract DialogueNode NextNode { get; }

        public DialogueNode(Text text) => this.text = text;

        public abstract bool CanBeFollowedByNode(DialogueNode node);

        public override string ToString()
        {
            return $"{Text}";
        }
    }
}
