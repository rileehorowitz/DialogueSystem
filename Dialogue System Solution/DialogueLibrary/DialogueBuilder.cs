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
        public static DialogueChoice[] BuildChoices(string[] choiceTexts, DialogueNode[] choiceNodes)
        {
            DialogueChoice[] choices = new DialogueChoice[choiceTexts.Length];
            for(int i = 0; i < choices.Length; i++)
            {
                choices[i] = BuildChoice(choiceTexts[i], choiceNodes[i]);
            }
            return choices;
        }

        //Method takes in an array of lines of text and determines what do do with it
        public static void BuildFromText(string[] lines)
        {
            for(int i = 0; i < lines.Length; i++)
            {
                int nextNodeLineIndex;
                string[] lineSegments = lines[i].Split(SplitChar);

                if (lineSegments[0].Equals("Scene"))
                {
                    //starting a new scene
                }
                else
                {
                    //we are in a scene
                    if (lineSegments[lineSegments.Length - 1].StartsWith("-"))
                    {
                        //we are looking at a Choice Node
                    }
                    else if(int.TryParse(lineSegments[lineSegments.Length - 1],out nextNodeLineIndex))
                    {
                        //we are looking at a Basic Node that points at a specific node that will follow it
                    }
                    else
                    {
                        //we are looking at a Basic Node that will be followed by the node on the next line
                    }
                    if (lineSegments[0].StartsWith("-"))
                    {
                        //we are looking at a node that follows a choice
                    }
                }

                for(int j = 0; j < lineSegments.Length; j++)
                {

                }
            }
        }
    }
    /*
     * Scene;Scene One
     * Rilee;Hello, World!
     * World;Hello, Rilee!;-Surprise;-Acceptance
     * -Rilee;Woah, I had no idea you could talk;5.
     * -Rilee;I always knew you could talk. You're chill.;6
     * World;Well I can talk, and I'm talking to you.;7
     * World;I'm glad you think so. I feel seen.
     * Rilee;What a day, this is great!
     * End
     */
}
