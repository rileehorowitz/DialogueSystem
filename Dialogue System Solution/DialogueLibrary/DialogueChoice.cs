using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialogueLibrary;

namespace DialogueLibrary
{
    public class DialogueChoice : IHasNextNode
    {
        private string choicePreview;
        private DialogueNode choiceNode;
        private bool condition;

        public DialogueChoice(string choicePreview, DialogueNode choiceNode)
        {
            this.choicePreview = choicePreview;
            NextNode = choiceNode;
        }
        public DialogueChoice(string choicePreview)
        {
            this.choicePreview = choicePreview;
        }

        public override string ToString()
        {
            return ChoicePreview;
        }

        public DialogueNode NextNode { get; set; }
        public int NextNodeKey { get; set; }
        public string ChoicePreview
        {
            get => choicePreview;
        }
    }
}
