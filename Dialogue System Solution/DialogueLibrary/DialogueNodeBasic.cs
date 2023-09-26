using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DialogueLibrary
{
    public class DialogueNodeBasic : DialogueNode
    {
        private DialogueNode? nextNode;

        //Read Only public property to access nextNode
        public ConsoleKey ContinueKey { get; set; } = ConsoleKey.Spacebar;
        public DialogueNodeBasic(DialogueNode nextNode, Text text)
            : base(text)
        {
            this.nextNode = nextNode;
        }
        public DialogueNodeBasic() { }

        //When attempting to move to a new node, check if the new node is our current node's next node
        public override bool CanBeFollowedByNode(DialogueNode node)
        {
            return nextNode == node;
        }
        public override DialogueNode GetInputForNextNode()
        {
            bool isValidInput = false;

            do
            {
                //clear any previous inputs
                while (Console.KeyAvailable) Console.ReadKey(true);

                //get the user input when trying to access the next node and check if its the correct input to continue (Spacebar)
                ConsoleKeyInfo inputKey = Console.ReadKey(true);

                isValidInput = inputKey.Key == ContinueKey;


            } while (!isValidInput);
            return nextNode;
        }
    }
}
