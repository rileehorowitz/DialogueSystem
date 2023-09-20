﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueLibrary
{
    public class DialogueChoice
    {
        private string choicePreview;
        private DialogueNode choiceNode;

        public DialogueChoice(string choicePreview, DialogueNode choiceNode)
        {
            this.choicePreview = choicePreview;
            this.choiceNode = choiceNode;
        }

        public override string ToString()
        {
            return ChoicePreview;
        }

        //Read Only public properties to access NextNode and ChoicePreview
        public DialogueNode NextNode
        {
            get => choiceNode;
        }
        public string ChoicePreview
        {
            get => choicePreview;
        }
    }
}