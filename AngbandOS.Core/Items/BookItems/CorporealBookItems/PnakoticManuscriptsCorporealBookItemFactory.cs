namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PnakoticManuscriptsCorporealBookItemFactory : CorporealBookItemFactory
    {
        private PnakoticManuscriptsCorporealBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override Colour Colour => Colour.BrightYellow;
        public override string Name => "[Pnakotic Manuscripts]";

        public override int[] Chance => new int[] { 3, 0, 0, 0 };
        public override int Cost => 100000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Pnakotic Manuscripts]";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 90;
        public override int[] Locale => new int[] { 90, 0, 0, 0 };
        public override int? SubCategory => 3;

        /// <summary>
        /// Returns true, because this book is a high level book.
        /// </summary>
        public override bool IsHighLevelBook => true;
        public override int Weight => 30;
        public override bool KindIsGood => true;
        public override Item CreateItem() => new PnakoticManuscriptsCorporealBookItem(SaveGame);

        public override Spell[] Spells => new Spell[]
        {
            SaveGame.SingletonRepository.Spells.Get<CorporealSpellHeroism>(),
            SaveGame.SingletonRepository.Spells.Get<CorporealSpellWraithform>(),
            SaveGame.SingletonRepository.Spells.Get<CorporealSpellAttunement>(),
            SaveGame.SingletonRepository.Spells.Get<CorporealSpellRestoreBody>(),
            SaveGame.SingletonRepository.Spells.Get<CorporealSpellHealingTrue>(),
            SaveGame.SingletonRepository.Spells.Get<CorporealSpellHypnoticEyes>(),
            SaveGame.SingletonRepository.Spells.Get<CorporealSpellRestoreSoul>(),
            SaveGame.SingletonRepository.Spells.Get<CorporealSpellInvulnerability>()
       };
    }
}