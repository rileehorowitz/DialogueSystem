namespace DialogueLibrary
{
    public class Speaker
    {
        private string name;
        private string? colorCode;
        private Dictionary<string, string> colorOptions = new Dictionary<string, string>()
        {
            {"black", "\u001b[30m"},
            {"red", "\u001b[31m"},
            {"green", "\u001b[32m"},
            {"yellow", "\u001b[33m"},
            {"blue", "\u001b[34m"},
            {"magenta", "\u001b[35m"},
            {"cyan", "\u001b[36m"},
            {"white", "\u001b[37m"}
        };
        //also hold variables to reference image or font

        public Speaker(string speakerName)
        {
            name = speakerName;
            AssignColor("white");
        }

        public Speaker(string speakerName, string textColor)
        {
            name = speakerName;
            AssignColor(textColor);
        }

        private void AssignColor(string color)
        {
            color = color.ToLower();
            if (colorOptions.ContainsKey(color))
            {
                colorCode = colorOptions[color];
            }
            else
            {
                colorCode = colorOptions["white"];
            }
        }
        public override string ToString()
        {
            return $"{colorCode}{name}\u001b[0m";
        }

    }
}