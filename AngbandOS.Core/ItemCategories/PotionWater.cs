namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionWater : PotionItemClass
    {
        private PotionWater(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Water";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Water";
        public override int Pval => 200;
        public override int? SubCategory => (int)PotionType.Water;
        public override int Weight => 4;

        public override bool Quaff(SaveGame saveGame)
        {
            // Water has no effect
            saveGame.MsgPrint("You feel less thirsty.");
            return true;
        }
        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            return true;
        }
    }
}
