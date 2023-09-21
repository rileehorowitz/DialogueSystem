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

        public static bool isWriting;

        public DialogueManager()
        {

        }
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

        private string ReadNode(DialogueNode node)
        {
            if (node != null)
            {
                string output = WriteText(node);
                //if input is good
                MoveToNode(node.NextNode);
                return output;
            }
            else //woah how'd we get here? The node we're reading is null, so we should return an empty string. If we're reading a null node, we should probably end the scene
            {
                EndScene();
                return "";
            }
        }

        private string WriteText(DialogueNode node)
        {
            isWriting = true;
            int writeDelay = 50;
            Console.WriteLine(node.Text.TextSpeaker);
            string nodeText = $"{node}";
            string displayText = "";

            //write the display text to the console one character at a time
            for(int i = 0; i < nodeText.Length; i++)
            {
                displayText = nodeText.Substring(0, i + 1);

                //store what line the dialogue starts on
                int startLine = Console.CursorTop;

                //print the current displayText
                Console.Write($"{displayText}");

                //store what line the dialogue ends on
                int endLine = Console.CursorTop;

                //wait so we get the appearance of typing
                Thread.Sleep(writeDelay); //would be sick to change the pause timer depnding on if we're at the end of a sentence or not. Check for punctuation.

                //clear the lines we just wrote to so we can write the updated text next pass
                for(int j = startLine; j < endLine; j++)
                {
                    Console.SetCursorPosition(0, j);
                    Console.Write(new string(' ', Console.WindowWidth));
                }
                //put our cursor back where we started, so we can print displayText on the correct row next pass
                Console.SetCursorPosition(0, startLine);

                //if we get user input while reading the text, skip to the end
                if (Console.KeyAvailable)
                {
                    displayText = nodeText;
                    break;
                }

            }
            //print the final version of displayText, which should now be the same as nodeText
            Console.WriteLine($"{displayText}");
            isWriting = false;

            return $"{node.Text.TextSpeaker}{displayText}";
        }
    }
}
