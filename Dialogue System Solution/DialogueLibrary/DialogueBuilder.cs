using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueLibrary
{
    public static class DialogueBuilder
    {
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

    }
}
