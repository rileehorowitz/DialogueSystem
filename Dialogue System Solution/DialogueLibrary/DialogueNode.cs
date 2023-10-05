using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueLibrary
{
    public abstract class DialogueNode : IHasNextNode
    {
        private Text text;
        private DialogueNode? nextNode;

        public Text Text { get => text; set => text = value; }
        public DialogueNode NextNode { get; set; }
        public int NextNodeKey { get; set; }

        public DialogueNode(Text text) => this.text = text;
        public DialogueNode() { }

        public abstract bool CanBeFollowedByNode(DialogueNode node);

        public abstract DialogueNode GetInputForNextNode();

        public override string ToString()
        {
            return $"{Text}";
        }
    }
}
