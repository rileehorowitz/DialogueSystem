using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueLibrary
{
    public static class DialogueBuilder
    {
        public const char SplitChar = ';';
        public static Scene BuildScene()
        {
            return new Scene();
        }
        public static Scene BuildScene(DialogueNode firstNode)
        {
            return new Scene(firstNode);
        }

        public static Speaker BuildSpeaker()
        {
            return new Speaker();
        }
        public static Speaker BuildSpeaker(string speakerName)
        {
            return new Speaker(speakerName);
        }
        public static Speaker BuildSpeaker(string speakerName, string textColor)
        {
            return new Speaker(speakerName, textColor);
        }

        public static Text BuildText()
        {
            return new Text();
        }
        public static Text BuildText(string text, Speaker speaker)
        {
            return new Text(text, speaker);
        }
        public static DialogueNode BuildNode()
        {
            return new DialogueNodeBasic();
        }
        public static DialogueNode BuildNode(DialogueNode nextNode, Text text)
        {
            return new DialogueNodeBasic(nextNode, text);
        }
        public static DialogueNode BuildNode(DialogueChoice[] choices, Text text)
        {
            return new DialogueNodeChoice(choices, text);
        }
        public static DialogueChoice BuildChoice(string text, DialogueNode nextNode)
        {
            return new DialogueChoice(text, nextNode);
        }
        public static DialogueChoice BuildChoice(string text)
        {
            return new DialogueChoice(text);
        }
        public static DialogueChoice[] BuildChoices(string[] choiceTexts, DialogueNode[] choiceNodes)
        {
            DialogueChoice[] choices = new DialogueChoice[choiceTexts.Length];
            for (int i = 0; i < choices.Length; i++)
            {
                choices[i] = BuildChoice(choiceTexts[i], choiceNodes[i]);
            }
            return choices;
        }

        public static Dictionary<string, Scene> scenes = new Dictionary<string, Scene>();
        public static Dictionary<string, DialogueNode> nodes = new Dictionary<string, DialogueNode>();
        public static Dictionary<string, Speaker> speakers = new Dictionary<string, Speaker>();
        //Method takes in an array of lines of text and determines what do do with it
        public static void BuildFromText(string[] lines)
        {
            Queue<IHasNextNode> waitingForNode = new Queue<IHasNextNode>();
            string currentSceneKey = "";
            string currentSpeakerKey = "";
            string currentNodeKey = "";
            int nextNodeLineIndex;
            int nodeCount = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] lineSegments = lines[i].Split(SplitChar);

                if (lineSegments[0].Equals("Scene"))
                {
                    //starting a new scene
                    currentSceneKey = lineSegments[lineSegments.Length - 1];
                    scenes[currentSceneKey] = BuildScene();
                }
                else if (lineSegments[0].Equals("End"))
                {
                    //we are ending a scene
                    waitingForNode.Dequeue().NextNode = null;
                }
                else
                {
                    //we are in a scene

                    //get the speaker of the node
                    currentSpeakerKey = lineSegments[0];
                    //if the speakers dictionary doesnt have our current speaker, add it
                    if (!speakers.ContainsKey(currentSpeakerKey)) { speakers[currentSpeakerKey] = BuildSpeaker(currentSpeakerKey); }
                    //make a new text object with the current speaker and current text
                    Text currentText = new Text(lineSegments[1], speakers[currentSpeakerKey]);

                    currentNodeKey = $"node{nodeCount}";
                    nodeCount++;

                    if (lineSegments[lineSegments.Length - 1].StartsWith("-"))
                    {
                        //we are looking at a Choice Node
                        DialogueChoice[] choices = new DialogueChoice[lineSegments.Length - 2];
                        for (int j = 2; j < lineSegments.Length; j++)
                        {
                            choices[j-2] = BuildChoice(lineSegments[j].Substring(1));
                            choices[j-2].NextNodeIndex = i + (j - 1);
                            waitingForNode.Enqueue(choices[j-2]);
                        }
                        nodes[currentNodeKey] = BuildNode(choices, currentText);
                    }
                    else
                    {
                        //we are looking at a Basic Node

                        //make a new node with the current text object
                        nodes[currentNodeKey] = BuildNode();
                        nodes[currentNodeKey].Text = currentText;

                        if (int.TryParse(lineSegments[lineSegments.Length - 1], out nextNodeLineIndex))
                        {
                            //set the next node as the node on the specified index line
                            nodes[currentNodeKey].NextNodeIndex = nextNodeLineIndex;
                        }
                        else
                        {
                            //set the next node as the node on the following line
                            nodes[currentNodeKey].NextNodeIndex = i + 1;
                        }
                        //add this node to the queue of nodes waiting for a next node
                        waitingForNode.Enqueue(nodes[currentNodeKey]);
                    }

                    if (lineSegments[0].StartsWith("-"))
                    {
                        //we are looking at a node that follows a choice
                    }

                    if (scenes[currentSceneKey].FirstNode == null)
                    {
                        scenes[currentSceneKey].FirstNode = nodes[currentNodeKey];
                    }
                    //if the current node we're on is the designated next node for the next node in the queue, dequeue that node and make our current node that waiting node's next node
                    if (waitingForNode.Peek().NextNodeIndex == i)
                    {
                        waitingForNode.Dequeue().NextNode = nodes[currentNodeKey];
                    }
                }
            }
        }
    }
    /*
    0 * Scene;Scene One
    1 * Rilee;Hello, World!
    2 * World;Hello, Rilee!;-Surprise;-Acceptance
    3 * Rilee;Woah, I had no idea you could talk;5.
    4 * Rilee;I always knew you could talk. You're chill.;6
    5 * World;Well I can talk, and I'm talking to you.;7
    6 * World;I'm glad you think so. I feel seen.
    7 * Rilee;What a day, this is great!
    8 * End
     */
}
