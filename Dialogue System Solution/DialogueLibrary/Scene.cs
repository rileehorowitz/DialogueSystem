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
        public Scene() { }
        public Scene(DialogueNode firstNode) => this.firstNode = firstNode;

        //Read Only public property to access firstNode
        public DialogueNode FirstNode
        {
            get => firstNode;
            set => firstNode = value;
        }
    }
}
