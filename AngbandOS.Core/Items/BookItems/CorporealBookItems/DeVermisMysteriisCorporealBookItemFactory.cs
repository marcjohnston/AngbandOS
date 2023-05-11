namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DeVermisMysteriisCorporealBookItemFactory : CorporealBookItemFactory
    {
        private DeVermisMysteriisCorporealBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override Colour Colour => Colour.BrightYellow;
        public override string Name => "[De Vermis Mysteriis]";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 25000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[De Vermis Mysteriis]";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => 2;

        /// <summary>
        /// Returns true, because this book is a high level book.
        /// </summary>
        public override bool IsHighLevelBook => true;
        public override int Weight => 30;
        public override bool KindIsGood => true;
        public override Item CreateItem() => new DeVermisMysteriisCorporealBookItem(SaveGame);

        public override Spell[] Spells => new Spell[]
        {
            SaveGame.SingletonRepository.Spells.Get<CorporealSpellHorrificVisage>(),
            SaveGame.SingletonRepository.Spells.Get<CorporealSpellSeeMagic>(),
            SaveGame.SingletonRepository.Spells.Get<CorporealSpellStoneSkin>(),
            SaveGame.SingletonRepository.Spells.Get<CorporealSpellMoveBody>(),
            SaveGame.SingletonRepository.Spells.Get<CorporealSpellMutateBody>(),
            SaveGame.SingletonRepository.Spells.Get<CorporealSpellKnowSelf>(),
            SaveGame.SingletonRepository.Spells.Get<CorporealSpellTeleportLevel>(),
            SaveGame.SingletonRepository.Spells.Get<CorporealSpellWordOfRecall>()
    };
    }
}
