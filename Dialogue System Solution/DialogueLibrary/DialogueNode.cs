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
        
        public DialogueNode(Text text)
        {
            NodeText = text;
        }

        //setting a public property of DialogueNode called NodeText
        public Text NodeText
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        public abstract bool CanBeFollowedByNode(DialogueNode node);

        public override string ToString()
        {
            return $"{NodeText}";
        }
    }
}
