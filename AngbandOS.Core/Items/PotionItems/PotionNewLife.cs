namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionNewLife : PotionItemClass
    {
        private PotionNewLife(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "New Life";

        public override int[] Chance => new int[] { 20, 10, 5, 0 };
        public override int Cost => 750000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "New Life";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 100, 120, 0 };
        public override int Pval => 100;
        public override int? SubCategory => (int)PotionType.NewLife;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // New life rerolls your health, cures all mutations, and restores you to your birth race
            saveGame.Player.RerollHitPoints();
            if (saveGame.Player.Dna.HasMutations)
            {
                saveGame.MsgPrint("You are cured of all mutations.");
                saveGame.Player.Dna.LoseAllMutations();
                saveGame.UpdateBonusesFlaggedAction.Set();
                saveGame.HandleStuff();
            }
            if (!(saveGame.Player.Race.GetType() == saveGame.Player.RaceAtBirth.GetType()))
            {
                var oldRaceName = saveGame.Player.RaceAtBirth.Title;
                saveGame.MsgPrint($"You feel more {oldRaceName} again.");
                saveGame.Player.ChangeRace(saveGame.Player.RaceAtBirth);
                saveGame.Level.RedrawSingleLocation(saveGame.Player.MapY, saveGame.Player.MapX);
            }
            return true;
        }
        public override Item CreateItem() => new NewLifePotionItem(SaveGame);
    }
}
