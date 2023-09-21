using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueLibrary
{
    public class DialogueNodeBasic : DialogueNode
    {
        private DialogueNode? nextNode;
        private ConsoleKey continueKey = ConsoleKey.Spacebar;

        //Read Only public property to access nextNode
        public override DialogueNode NextNode
        {
            get
            {
                bool isValidInput = false;
                do
                {
                    //clear any previous inputs
                    while (Console.KeyAvailable) Console.ReadKey(true);

                    //get the user input when trying to access the next node and check if its the correct input to continue (Spacebar)
                    ConsoleKeyInfo inputKey = Console.ReadKey(true);
                    isValidInput = inputKey.Key == continueKey;
                } while (!isValidInput);
                return nextNode;
            }
        }
        public DialogueNodeBasic(DialogueNode nextNode, Text text)
            : base(text)
        {
            this.nextNode = nextNode;
        }

        //When attempting to move to a new node, check if the new node is our current node's next node
        public override bool CanBeFollowedByNode(DialogueNode node)
        {
            return nextNode == node;
        }
    }
}
