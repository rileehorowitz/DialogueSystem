using DialogueLibrary;
namespace DialogueApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Speaker speakerOne = new Speaker("Rilee", "red");
            Speaker speakerTwo = new Speaker("World", "cyan");

            Text textOne = new Text("Hello, World!", speakerOne);
            Text textTwo = new Text("Hello, Rilee!", speakerTwo);
            Text textThree = new Text("Woah, who said that?", speakerOne);
            Text textFour = new Text("Oh my god, the world in \"Hello, World!\" can talk? I'm such a huge fan.", speakerOne);
            Text textFive = new Text("Well, I do love meeting my fans.", speakerTwo);
            Text textSix = new Text("Wow, you're great, World", speakerOne);

            DialogueNodeBasic dialogueNodeSix = new DialogueNodeBasic(null, textSix);
            DialogueNodeBasic dialogueNodeFive = new DialogueNodeBasic(dialogueNodeSix, textFive);
            DialogueNodeBasic dialogueNodeFour = new DialogueNodeBasic(dialogueNodeFive, textFour);
            DialogueNodeBasic dialogueNodeThree = new DialogueNodeBasic(dialogueNodeFour, textThree);
            DialogueNodeBasic dialogueNodeTwo = new DialogueNodeBasic(dialogueNodeThree, textTwo);
            DialogueNodeBasic dialogueNodeOne = new DialogueNodeBasic(dialogueNodeTwo, textOne);

            Scene sceneOne = new Scene(dialogueNodeOne);
            DialogueManager manager = new DialogueManager(sceneOne);

        }
    }
}