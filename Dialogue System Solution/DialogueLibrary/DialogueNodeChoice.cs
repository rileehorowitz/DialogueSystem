using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DialogueLibrary
{
    public class DialogueNodeChoice : DialogueNode
    {
        private DialogueChoice[] choices;

        //Read Only public property to access nextNode and choices

        public DialogueChoice[] Choices { get => choices; set => choices = value; }

        public DialogueNodeChoice(DialogueChoice[] choices, Text text)
            : base(text)
        {
            this.choices = choices;
        }
        public DialogueNodeChoice() { }
        public override DialogueNode GetInputForNextNode()
        {
            bool isValidInput = false;
            int choice;
            do
            {
                //clear any previous inputs
                while (Console.KeyAvailable) Console.ReadKey(true);

                ConsoleKeyInfo choiceKey = Console.ReadKey(true);
                isValidInput = (Int32.TryParse(choiceKey.KeyChar.ToString(), out choice) && choice <= Choices.Length && choice > 0);
            } while (!isValidInput);
            NextNode = Choices[choice - 1].ChoiceNode;
            return NextNode;
        }

        public string GetChoicesText()
        {
            string output = "\n";
            for (int i = 0; i < Choices.Length; i++)
            {
                output += $"\n{i + 1}. {Choices[i]}";
            }
            return output;
        }

        //When attempting to move to a new node, check if the new node is our current node's next node
        public override bool CanBeFollowedByNode(DialogueNode node)
        {
            //if the array of choices contains the passed in node, return true
            return choices.Any(x => x.ChoiceNode == node);
        }
        public override string ToString()
        {
            string output = $"{Text}";
            output += GetChoicesText();
            return output;
        }   
    }
}
