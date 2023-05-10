namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class CthaatAquadingenNatureBookItemFactory : NatureBookItemFactory
    {
        private CthaatAquadingenNatureBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override Colour Colour => Colour.Green;
        public override string Name => "[Cthaat Aquadingen]";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 100000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Cthaat Aquadingen]";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 80;
        public override int[] Locale => new int[] { 80, 0, 0, 0 };
        public override int? SubCategory => 3;
        public override int Weight => 30;
        public override bool KindIsGood => true;
        public override Item CreateItem() => new CthaatAquadingenNatureBookItem(SaveGame);

        public override Spell[] Spells => new Spell[]
        {
            SaveGame.SingletonRepository.Spells.Get<NatureSpellEarthquake>(),
            SaveGame.SingletonRepository.Spells.Get<NatureSpellWhirlwindAttack>(),
            SaveGame.SingletonRepository.Spells.Get<NatureSpellBlizzard>(),
            SaveGame.SingletonRepository.Spells.Get<NatureSpellLightningStorm>(),
            SaveGame.SingletonRepository.Spells.Get<NatureSpellWhirlpool>(),
            SaveGame.SingletonRepository.Spells.Get<NatureSpellCallSunlight>(),
            SaveGame.SingletonRepository.Spells.Get<NatureSpellElementalBranding>(),
            SaveGame.SingletonRepository.Spells.Get<NatureSpellNaturesWrath>()
        };
    }
}
