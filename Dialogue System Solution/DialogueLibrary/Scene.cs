using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueLibrary
{
    public class Scene
    {
        private DialogueNode firstNode;

        public Scene(DialogueNode firstNode)
        {
            FirstNode = firstNode;
        }

        public DialogueNode FirstNode
        {
            get
            {
                return firstNode;
            }
            set
            {
                firstNode = value;
            }
        }
    }
}
