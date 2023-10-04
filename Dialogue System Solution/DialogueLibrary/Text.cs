using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueLibrary
{
    public class Text
    {
        private string dialogueText;
        private Speaker textSpeaker;

        public Text() { }
        public Text(string dialogueText, Speaker textSpeaker)
        {
            this.dialogueText = dialogueText;
            this.textSpeaker = textSpeaker;
        }
        public Text(string dialogueText)
        {
            this.dialogueText = dialogueText;
            this.textSpeaker = null;
        }
        public override string ToString() 
        {
            return $"{DialogueText}";
        }

        //Read Only properties to access dialogueText and textSpeaker
        public string DialogueText
        {
            get => dialogueText;
            set => dialogueText = value;
        }
        public Speaker TextSpeaker
        {
            get => textSpeaker;
            set => textSpeaker = value;
        }
    }
}
