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
    }
}