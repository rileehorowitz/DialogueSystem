﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueLibrary
{
    public static class DialoguePrinter
    {
        private const int LetterWriteDelay = 50;
        private const int CommaWriteDelay = 150;
        private const int PunctuationWriteDelay = 200;

        public static bool IsWriting { get; private set; }
        public static int WriteDelay { get; private set; } = LetterWriteDelay;
        public static string TextToPrint { get; private set; } = "";

        public static void PrintText(DialogueNode node, bool printOneAtATime)
        {
            IsWriting = true;
            TextToPrint = "";
            if (node.Text.TextSpeaker != null)
            {
                Console.WriteLine(node.Text.TextSpeaker);
            }
            string nodeText = $"{node}";

            //add line breaks where necessary to fit within the console
            if (nodeText.Length > Console.WindowWidth)
            {
                string[] words = nodeText.Split(" ");
                int indexCount = 0;
                int lineCount = 0;
                foreach (string word in words)
                {
                    indexCount += word.Length;
                    lineCount += word.Length;
                    if (lineCount > Console.WindowWidth)
                    {
                        nodeText = nodeText.Insert(indexCount - word.Length, "\n");
                        lineCount = word.Length;
                    }
                    indexCount++;
                    lineCount++;
                }
            }

            if (printOneAtATime)
            {
                PrintOneCharAtATime(nodeText);
            }
            else
            {
                TextToPrint = nodeText;
            }

            //print the final version of TextToPrint, which should now be the same as nodeText
            Console.WriteLine($"{TextToPrint}\n");
            IsWriting = false;
        }
        public static void PrintText(string text, bool printOneAtATime)
        {
            IsWriting = true;
            TextToPrint = "";

            //add line breaks where necessary to fit within the console
            if (text.Length > Console.WindowWidth)
            {
                string[] words = text.Split(" ");
                int indexCount = 0;
                int lineCount = 0;
                foreach (string word in words)
                {
                    indexCount += word.Length;
                    lineCount += word.Length;
                    if (lineCount > Console.WindowWidth)
                    {
                        text = text.Insert(indexCount - word.Length, "\n");
                        lineCount = word.Length;
                    }
                    indexCount++;
                    lineCount++;
                }
            }

            if (printOneAtATime)
            {
                PrintOneCharAtATime(text);
            }
            else
            {
                TextToPrint = text;
            }

            //print the final version of TextToPrint, which should now be the same as nodeText
            Console.WriteLine($"{TextToPrint}\n");
            IsWriting = false;
        }

        private static void PrintOneCharAtATime(string nodeText)
        {
            
            for (int i = 0; i < nodeText.Length; i++)
            {
                //store the current chunk of the full dialogue text
                TextToPrint = nodeText.Substring(0, i + 1);
                
                //determine delay based on what current character we're adding
                char lastChar = TextToPrint[TextToPrint.Length - 1];
                DetermineDelay(lastChar);

                int lineBreaks = 0;
                foreach(char character in TextToPrint)
                {
                    if(character == '\n')
                    {
                        lineBreaks++;
                    }
                }

                //print the current displayText
                Console.Write($"{TextToPrint}");

                //store what line the dialogue ends on and starts on
                int endLine = Console.CursorTop;
                int startLine = endLine - lineBreaks;

                //wait so we get the appearance of typing
                Thread.Sleep(WriteDelay);

                ClearConsoleLines(startLine, endLine);

                //if we get user input while reading the text, skip to the end
                if (Console.KeyAvailable)
                {
                    TextToPrint = nodeText;
                    break;
                }
            }
        }

        private static void ClearConsoleLines(int startLine, int endLine)
        {
            for (int i = startLine; i <= endLine; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, startLine);
        }

        private static void DetermineDelay(char lastChar)
        {
            if (Char.IsPunctuation(lastChar) && lastChar != '\'' && lastChar != '\"')
            {
                if (lastChar == ',')
                {
                    WriteDelay = CommaWriteDelay;
                }
                else
                {
                    WriteDelay = PunctuationWriteDelay;
                }
            }
            else
            {
                WriteDelay = LetterWriteDelay;
            }
        }
    }
}
