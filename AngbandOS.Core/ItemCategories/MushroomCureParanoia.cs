namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class MushroomCureParanoia : MushroomFoodItemClass
    {
        private MushroomCureParanoia(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ',';
        public override string Name => "Cure Paranoia";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 25;
        public override string FriendlyName => "Cure Paranoia";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 14;
        public override int Weight => 1;
        public override bool Eat(SaveGame saveGame)
        {
            if (saveGame.Player.SetTimedFear(0))
            {
                return true;
            }
            return false;
        }
    }
}
