namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DholChantsLifeBookItemFactory : LifeBookItemFactory
    {
        private DholChantsLifeBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "[Dhol Chants]";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 25000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Dhol Chants]";
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
        public override Item CreateItem() => new DholChantsLifeBookItem(SaveGame);

        public override Spell[] Spells => new Spell[]
        {
            SaveGame.SingletonRepository.Spells.Get<LifeSpellExorcism>(),
            SaveGame.SingletonRepository.Spells.Get<LifeSpellDispelCurse>(),
            SaveGame.SingletonRepository.Spells.Get<LifeSpellDispelUndeadAndDemons>(),
            SaveGame.SingletonRepository.Spells.Get<LifeSpellDayOfTheDove>(),
            SaveGame.SingletonRepository.Spells.Get<LifeSpellDispelEvil>(),
            SaveGame.SingletonRepository.Spells.Get<LifeSpellBanish>(),
            SaveGame.SingletonRepository.Spells.Get<LifeSpellHolyWord>(),
            SaveGame.SingletonRepository.Spells.Get<LifeSpellWardingTrue>()
        };
    }
}