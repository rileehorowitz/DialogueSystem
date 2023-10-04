using DialogueLibrary;
namespace DialogueApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = new string[]
            {
                "Scene|Scene One|An Imperial sled driving four penguin prisoners down an icy tundra road. All are seated and bound; the one dressed in finery is gagged.",
                "Ralof/cyan|Hey, you. You’re finally awake. You were trying to cross the border, right? Walked right into that Imperial ambush, same as us, and that thief over there.",
                "Little Lokir/red|Damn you Macaroni penguins. The Tundra was fine until you came along. Emperor penguins were nice and lazy.",
                "Little Lokir|If they hadn’t been looking for you, I could’ve stolen that seal and been half way to Glacierfell.",
                "Little Lokir|You there. You and me — we shouldn't be here. It’s these Macaroni the Emperors want.|-Remain Silent|-Agree With Lokir",
                "...|2",
                "You nod an affirmation",
                "Ralof|We’re all huddle-mates in binds now, thief.",
                "Emperor Soldier/yellow|Shut up back there!",
                "Little Lokir looks at the gagged man.",
                "Little Lokir|And what's wrong with him?",
                "Ralof|Watch your beak! You're speaking to Ulfric Macaroni, the true High King of Victorian London.",
                "Little Lokir|Ulfric? The Duke of Wimblehelm? You're the leader of the rebellion! But if they captured you... Oh lights, where are they taking us?",
                "The gagged man says nothing, but does seem to have an air of Macaroni royalty to him. You've never seen a more dignified Macaroni penguin.",
                "Ralof|I don't know where we're going, but the Northern Lights await.",
                "You approach a large city: Victorian London. An Emperor soldier calls out to the lead sled.",
                "Emperor Soldier|General, sir! The iceman is waiting!",
                "Emperor General/yellow|Good. Let's get this over with.",
                "End|Scene Two",
                "Scene|Scene Two|Smoke and soot choke the air in the middle of Victorian London. In the town square, the Emperor penguins prepare to sentence their new prisoners.",
                "End"

            };
            DialogueBuilder.BuildFromText(lines);
            DialogueManager manager = new DialogueManager();
            manager.StartScene(DialogueBuilder.scenes["Scene One"]);

        }
    }
}