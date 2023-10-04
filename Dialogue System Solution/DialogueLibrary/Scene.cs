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
        public string Description { get; set; } = "";
        public Scene NextScene { get; set; }
        public Scene() { }
        public Scene(DialogueNode firstNode) => this.firstNode = firstNode;
        public Scene(DialogueNode firstNode, string description)
        {
            this.firstNode = firstNode;
            Description = description;
        }

        //Read Only public property to access firstNode
        public DialogueNode FirstNode
        {
            get => firstNode;
            set => firstNode = value;
        }
    }
}
