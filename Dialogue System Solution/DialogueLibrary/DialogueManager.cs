using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueLibrary
{
    public class DialogueManager
    {
        private Scene currentScene;
        private DialogueNode currentNode;

        public DialogueManager()
        {

        }

        public void StartScene(Scene scene)
        {
            if (currentScene != null)
            {
                currentScene = scene;
                currentNode = currentScene.FirstNode;
            }
        }

        public void StartNode(DialogueNode node)
        {
            if(currentNode != null)
            {
                currentNode = node;
                ReadNode(currentNode);
            }
        }

        public string ReadNode(DialogueNode node)
        {
            return "";
        }

        public string ReadNode(DialogueNodeChoice node)
        {
            return "";
        }
    }
}
