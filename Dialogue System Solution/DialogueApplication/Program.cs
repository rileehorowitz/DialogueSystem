using DialogueLibrary;
namespace DialogueApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Speaker speaker = new Speaker("Rilee", "cyan");

            Text text = new Text("Hello, World!", speaker);

            DialogueNodeBasic dialogueNodeTwo = new DialogueNodeBasic(null, text);
            DialogueNodeBasic dialogueNodeOne = new DialogueNodeBasic(dialogueNodeTwo, text);

            Console.WriteLine(dialogueNodeOne);
        }
    }
}