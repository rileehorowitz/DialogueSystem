using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueLibrary
{
    public static class DialogueBuilder
    {
        public const char SplitChar = '|';
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
        public static Dictionary<int, DialogueNode> nodes = new Dictionary<int, DialogueNode>();
        public static Dictionary<string, Speaker> speakers = new Dictionary<string, Speaker>();
        //Method takes in an array of lines of text and determines what do do with it
        public static void BuildFromText(string[] lines)
        {
            Queue<IHasNextNode> waitingForNode = new Queue<IHasNextNode>();
            string currentSceneKey = "";
            string currentSpeakerKey = "";
            int currentNodeKey;
            int linesToSkip;
            int nodeCount = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] lineSegments = lines[i].Split(SplitChar);

                if (lineSegments[0].Equals("Scene"))
                {
                    //starting a new scene
                    currentSceneKey = lineSegments[1];
                    if (!scenes.ContainsKey(currentSceneKey))
                    {
                        scenes[currentSceneKey] = BuildScene();
                    }
                    if (lineSegments.Length > 2)
                    {
                        scenes[currentSceneKey].Description = lineSegments[2];
                    }
                }
                else if (lineSegments[0].Equals("End"))
                {
                    //we are ending a scene
                    if (waitingForNode.Count > 0)
                    {
                        waitingForNode.Dequeue().NextNode = null;
                    }
                    if (lineSegments.Length > 1)
                    {
                        if (!scenes.ContainsKey(lineSegments[1]))
                        {
                            scenes[lineSegments[1]] = BuildScene();
                        }
                        scenes[currentSceneKey].NextScene = scenes[lineSegments[1]];
                    }
                }
                else
                {
                    //we are in a scene
                    Text currentText;
                    if (lineSegments.Length <= 1 || lineSegments.Length <= 2 && int.TryParse(lineSegments[lineSegments.Length - 1], out linesToSkip))
                    {
                        currentText = new Text(lineSegments[0]);
                    }
                    else
                    {
                        //get the speaker of the node
                        currentSpeakerKey = lineSegments[0];

                        //if the speakers dictionary doesnt have our current speaker, add it
                        if (!speakers.ContainsKey(currentSpeakerKey.Split('/')[0]))
                        {
                            string currentSpeakerColor = "white";
                            if (currentSpeakerKey.Split('/').Length > 1)
                            {
                                currentSpeakerKey = lineSegments[0].Split('/')[0];
                                currentSpeakerColor = lineSegments[0].Split('/')[1];
                            }

                            speakers[currentSpeakerKey] = BuildSpeaker(currentSpeakerKey, currentSpeakerColor);
                        }
                        //make a new text object with the current speaker and current text
                        currentText = new Text(lineSegments[1], speakers[currentSpeakerKey]);
                    }
                    currentNodeKey = i;
                    nodeCount++;

                    if (lineSegments[lineSegments.Length - 1].StartsWith("~"))
                    {
                        //we are looking at a Choice Node
                        DialogueChoice[] choices = new DialogueChoice[lineSegments.Length - 2];
                        for (int j = 2; j < lineSegments.Length; j++)
                        {
                            choices[j - 2] = BuildChoice(lineSegments[j].Substring(1));
                            choices[j - 2].NextNodeKey = i + (j - 1);
                            waitingForNode.Enqueue(choices[j - 2]);
                        }
                        nodes[currentNodeKey] = BuildNode(choices, currentText);
                    }
                    else
                    {
                        //we are looking at a Basic Node

                        //make a new node with the current text object
                        nodes[currentNodeKey] = BuildNode();
                        nodes[currentNodeKey].Text = currentText;

                        if (int.TryParse(lineSegments[lineSegments.Length - 1], out linesToSkip))
                        {
                            //set the next node as the node on the specified index line
                            nodes[currentNodeKey].NextNodeKey = i + linesToSkip;
                        }
                        else
                        {
                            //set the next node as the node on the following line
                            nodes[currentNodeKey].NextNodeKey = i + 1;
                        }
                        //add this node to the queue of nodes waiting for a next node
                        waitingForNode.Enqueue(nodes[currentNodeKey]);
                    }

                    if (scenes[currentSceneKey].FirstNode == null)
                    {
                        scenes[currentSceneKey].FirstNode = nodes[currentNodeKey];
                    }
                    //if the current node we're on is the designated next node for the next node in the queue, or the designated next node for a node in the queue has already been created, dequeue that node and make our current node that waiting node's next node
                    while (waitingForNode.Count > 0 && waitingForNode.Peek().NextNodeKey <= i)
                    {
                        int key = waitingForNode.Peek().NextNodeKey;
                        waitingForNode.Dequeue().NextNode = nodes[key];
                    }
                }
            }
        }
    }
}
