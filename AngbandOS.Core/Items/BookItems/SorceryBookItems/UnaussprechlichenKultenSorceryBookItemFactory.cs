namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class UnaussprechlichenKultenSorceryBookItemFactory : SorceryBookItemFactory
    {
        private UnaussprechlichenKultenSorceryBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override Colour Colour => Colour.Blue;
        public override string Name => "[Unaussprechlichen Kulten]";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 25000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Unaussprechlichen Kulten]";
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
        public override Item CreateItem() => new UnaussprechlichenKultenSorceryBookItem(SaveGame);

        public override Spell[] Spells => new Spell[]
        {
            SaveGame.SingletonRepository.Spells.Get<SorcerySpellDetectObjectsAndTreasure>(),
            SaveGame.SingletonRepository.Spells.Get<SorcerySpellDetectEnchantment>(),
            SaveGame.SingletonRepository.Spells.Get<SorcerySpellCharmMonster>(),
            SaveGame.SingletonRepository.Spells.Get<SorcerySpellDimensionDoor>(),
            SaveGame.SingletonRepository.Spells.Get<SorcerySpellSenseMinds>(),
            SaveGame.SingletonRepository.Spells.Get<SorcerySpellSelfKnowledge>(),
            SaveGame.SingletonRepository.Spells.Get<SorcerySpellTeleportLevel>(),
            SaveGame.SingletonRepository.Spells.Get<SorcerySpellWordOfRecall>()
        };
    }
}