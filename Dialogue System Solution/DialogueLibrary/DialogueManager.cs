using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueLibrary
{
    public class DialogueManager
    {
        private Scene? currentScene;
        private DialogueNode? currentNode;

        public DialogueManager() { }
        public DialogueManager(Scene scene) => StartScene(scene);

        public void StartScene(Scene scene)
        {
            if (currentScene == null)
            {
                currentScene = scene;
                StartNode(currentScene.FirstNode);
            }
            //Else, we're already in a scene
        }
        private void EndScene()
        {
            if (currentScene != null)
            {
                currentScene = null;
            }//Else, we aren't in a scene
            if (currentNode != null)
            {
                currentNode = null;
            }
        }
        private void StartNode(DialogueNode node)
        {
            currentNode = node;

            if (currentNode != null) //if we arent at the end of a scene
            {
                ReadNode(currentNode);
            }
            else //we're trying to start a node, but we're at the end of the scene. End the scene instead
            {
                EndScene();
            }
            
        }
        //Called when a the current node has receieved input and its time to move to the next node.
        private void MoveToNode(DialogueNode node)
        {
            if (currentNode != null)
            {
                if (currentNode.CanBeFollowedByNode(node))
                {
                    StartNode(node);
                }
            }
            else //woah how'd we get here? Our currentNode is null, so we should be ending the scene
            {
                EndScene();
            }
        }
        private void ReadNode(DialogueNode node)
        {
            if (node != null)
            {
                DialoguePrinter.PrintText(node, true);
            }
            else //woah how'd we get here? The node we're reading is null, so we should return an empty string. If we're reading a null node, we should probably end the scene
            {
                EndScene();
                return;
            }
            //if input is good go to the next node
            MoveToNode(node.NextNode);
        } 
    }
}