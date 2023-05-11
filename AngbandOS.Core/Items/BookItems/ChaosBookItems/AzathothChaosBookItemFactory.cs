namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class AzathothChaosBookItemFactory : ChaosBookItemFactory
    {
        private AzathothChaosBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override Colour Colour => Colour.Red;
        public override string Name => "[The Book of Azathoth]";

        public override int[] Chance => new int[] { 3, 0, 0, 0 };
        public override int Cost => 100000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[The Book of Azathoth]";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 100;
        public override int[] Locale => new int[] { 100, 0, 0, 0 };
        public override int? SubCategory => 3;

        /// <summary>
        /// Returns true, because this book is a high level book.
        /// </summary>
        public override bool IsHighLevelBook => true;

        public override int Weight => 30;
        public override bool KindIsGood => true;
        public override Item CreateItem() => new AzathothChaosBookItem(SaveGame);

        public override Spell[] Spells => new Spell[]
        {
            SaveGame.SingletonRepository.Spells.Get<ChaosSpellGravityBeam>(),
            SaveGame.SingletonRepository.Spells.Get<ChaosSpellMeteorSwarm>(),
            SaveGame.SingletonRepository.Spells.Get<ChaosSpellFlameStrike>(),
            SaveGame.SingletonRepository.Spells.Get<ChaosSpellCallChaos>(),
            SaveGame.SingletonRepository.Spells.Get<ChaosSpellShardBall>(),
            SaveGame.SingletonRepository.Spells.Get<ChaosSpellManaStorm>(),
            SaveGame.SingletonRepository.Spells.Get<ChaosSpellBreatheChaos>(),
            SaveGame.SingletonRepository.Spells.Get<ChaosSpellCallTheVoid>()
        };
    }
}
