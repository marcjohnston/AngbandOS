namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodSleepMonster : RodItemClass
    {
        private RodSleepMonster(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Sleep Monster";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Sleep Monster";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 16;
        public override int Weight => 15;
        public override void Execute(ZapRodEvent zapRodEvent)
        {
            if (SaveGame.SleepMonster(zapRodEvent.Dir.Value))
            {
                zapRodEvent.Identified = true;
            }
            zapRodEvent.Item.TypeSpecificValue = 18;
        }
        public override Item CreateItem(SaveGame saveGame) => new SleepMonsterRodItem(saveGame);
    }
}
