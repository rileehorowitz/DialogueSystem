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
        private DialogueNode nextNode;

        public DialogueNode(Text text) => this.text = text;

        //Read Only public property to access text
        public Text Text
        {
            get => text;
        }

        //Read Only public property to access nextNode
        public abstract DialogueNode NextNode
        {
            get;
        }

        public abstract bool CanBeFollowedByNode(DialogueNode node);

        public override string ToString()
        {
            return $"{Text}";
        }
    }
}
