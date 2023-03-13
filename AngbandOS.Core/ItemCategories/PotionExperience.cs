namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionExperience : PotionItemClass
    {
        private PotionExperience(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Experience";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 25000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Experience";
        public override int Level => 65;
        public override int[] Locale => new int[] { 65, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.Experience;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Experience increases your experience points by 50%, with a minimum of +10 and
            // maximuum of +10,000
            if (saveGame.Player.ExperiencePoints < Constants.PyMaxExp)
            {
                int ee = (saveGame.Player.ExperiencePoints / 2) + 10;
                if (ee > 100000)
                {
                    ee = 100000;
                }
                saveGame.MsgPrint("You feel more experienced.");
                saveGame.Player.GainExperience(ee);
                return true;
            }
            return false;
        }
        public override Item CreateItem(SaveGame saveGame) => new ExperiencePotionItem(saveGame);
    }
}
