namespace AngbandOS.Core.BirthStages
{
    internal class IntroductionBirthStage : BaseBirthStage
    {
        private IntroductionBirthStage(SaveGame saveGame) : base(saveGame) { }
        public override string[] GetMenu()
        {
            List<string> menuItems = new List<string>();
            menuItems.Add("Choose");
            menuItems.Add("Random");
            menuItems.Add("Re-use");
            return menuItems.ToArray();
        }
        public override void RenderSelection(int index)
        {
            switch (index)
            {
                case 0:
                    SaveGame.Screen.Print(Colour.Purple, "Choose your character's race, sex, and class; and select", 35, 20);
                    SaveGame.Screen.Print(Colour.Purple, "which realms of magic your character will use.", 36, 20);
                    break;

                case 1:
                    SaveGame.Screen.Print(Colour.Purple, "Let the game generate a character for you randomly.", 35, 20);
                    break;

                case 2:
                    SaveGame.Screen.Print(Colour.Purple, "Re-play with a character similar to the one you played", 35, 20);
                    SaveGame.Screen.Print(Colour.Purple, "last time.", 36, 20);
                    break;
            }
        }
    }
}