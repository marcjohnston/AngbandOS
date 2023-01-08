namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionDetectInvisible : PotionItemClass
    {
        private PotionDetectInvisible(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Detect Invisible";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 50;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Detect Invisible";
        public override int Level => 3;
        public override int[] Locale => new int[] { 3, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.DetectInvis;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Detect invisible gives you times see invisibility
            return saveGame.Player.TimedSeeInvisibility.SetTimer(saveGame.Player.TimedSeeInvisibility.TimeRemaining + 12 + Program.Rng.DieRoll(12));
        }
    }
}
