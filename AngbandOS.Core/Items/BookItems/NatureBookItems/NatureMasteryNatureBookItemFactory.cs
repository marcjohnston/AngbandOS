namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class NatureMasteryNatureBookItemFactory : NatureBookItemFactory
    {
        private NatureMasteryNatureBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "[Nature Mastery]";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Nature Mastery]";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => 1;
        public override int Weight => 30;
        public override bool KindIsGood => false;
        public override Item CreateItem() => new NatureMasteryNatureBookItem(SaveGame);

        public override Spell[] Spells => new Spell[] {
            new NatureSpellStoneToMud(),
            new NatureSpellLightningBolt(),
            new NatureSpellNatureAwareness(),
            new NatureSpellFrostBolt(),
            new NatureSpellRayOfSunlight(),
            new NatureSpellEntangle(),
            new NatureSpellSummonAnimal(),
            new NatureSpellHerbalHealing()
        };
    }
}
