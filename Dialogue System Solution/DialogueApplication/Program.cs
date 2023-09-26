using DialogueLibrary;
namespace DialogueApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Speaker speakerOne = new Speaker("Rilee", "red");
            //Speaker speakerTwo = new Speaker("World", "cyan");

            //Text textOne = new Text("Hello, World!", speakerOne);
            //Text textTwo = new Text("Hello, Rilee!", speakerTwo);
            //Text textThree = new Text("Woah, who said that?", speakerOne);
            //Text textFour = new Text("Oh my god, the world in \"Hello, World!\" can talk? I'm such a huge fan.", speakerOne);
            //Text textFive = new Text("Well, I do love meeting my fans.", speakerTwo);
            //Text textSix = new Text("Wow, you're great, World", speakerOne);

            //DialogueNodeBasic dialogueNodeSix = new DialogueNodeBasic(null, textSix);
            //DialogueNodeBasic dialogueNodeFive = new DialogueNodeBasic(dialogueNodeSix, textFive);
            //DialogueNodeBasic dialogueNodeFour = new DialogueNodeBasic(dialogueNodeFive, textFour);
            //DialogueNodeBasic dialogueNodeThree = new DialogueNodeBasic(dialogueNodeFour, textThree);
            //DialogueNodeBasic dialogueNodeTwo = new DialogueNodeBasic(dialogueNodeThree, textTwo);
            //DialogueNodeBasic dialogueNodeOne = new DialogueNodeBasic(dialogueNodeTwo, textOne);

            //Scene sceneOne = new Scene(dialogueNodeOne);
            //DialogueManager manager = new DialogueManager(sceneOne);

            //Text cTextOne = new Text("Hello, World!", speakerOne);
            //Text cTextTwo = new Text("Hello, Rilee!", speakerTwo);
            //Text cTextThreeA = new Text("Woah, who said that?", speakerOne);
            //Text cTextThreeB = new Text("Oh my god, the world in \"Hello, World!\" can talk? I'm such a huge fan.", speakerOne);
            //Text cTextFourA = new Text("It's me, the world from \"Hello, World!\" Don't you like me?", speakerTwo);
            //Text cTextFourB = new Text("Well, I do love meeting my fans. I'm glad you like me!", speakerTwo);
            //Text cTextFive = new Text("I like you a lot, World. <3", speakerOne);

            //DialogueNodeBasic choiceNodeFive = new DialogueNodeBasic(null, cTextFive);

            //DialogueNodeBasic choiceNodeFourA = new DialogueNodeBasic(choiceNodeFive, cTextFourA);
            //DialogueNodeBasic choiceNodeFourB = new DialogueNodeBasic(choiceNodeFive, cTextFourB);

            //DialogueNodeBasic choiceNodeThreeA = new DialogueNodeBasic(choiceNodeFourA, cTextThreeA);
            //DialogueNodeBasic choiceNodeThreeB = new DialogueNodeBasic(choiceNodeFourB, cTextThreeB);

            //DialogueChoice choiceOne = new DialogueChoice("Who Said That?", choiceNodeThreeA);
            //DialogueChoice choiceTwo = new DialogueChoice("World? I'm a Huge Fan", choiceNodeThreeB);

            //DialogueChoice[] choices = new DialogueChoice[2]{
            //    choiceOne,
            //    choiceTwo
            //};

            //DialogueNodeChoice choiceNodeTwo = new DialogueNodeChoice(choices, cTextTwo);
            //DialogueNodeBasic choiceNodeOne = new DialogueNodeBasic(choiceNodeTwo, cTextOne);

            //Scene sceneTwo = new Scene(choiceNodeOne);
            //manager.StartScene(sceneTwo);


            string[] lines = new string[]
            {
                "Scene;Scene One",
                "Rilee;Hello, World!",
                "World;Hello, Rilee!;-Surprise;-Acceptance",
                "Rilee;Woah, I had no idea you could talk;5",
                "Rilee;I always knew you could talk. You're chill.;6",
                "World;Well I can talk, and I'm talking to you.;7",
                "World;I'm glad you think so. I feel seen.",
                "Rilee;What a day, this is great!",
                "End"
            };
            DialogueBuilder.BuildFromText(lines);
            DialogueManager manager = new DialogueManager();
            manager.StartScene(DialogueBuilder.scenes["Scene One"]);

        }
    }
}