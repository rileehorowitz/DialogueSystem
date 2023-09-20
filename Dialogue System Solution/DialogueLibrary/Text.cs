using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueLibrary
{
    public class Text
    {
        private string text;
        private Speaker speaker;

        public Text(string dialogueText, Speaker textSpeaker)
        {
            text = dialogueText;
            speaker = textSpeaker;
        }
        public override string ToString() 
        {
            return $"{speaker}\n{text}";
        }
    }
}
