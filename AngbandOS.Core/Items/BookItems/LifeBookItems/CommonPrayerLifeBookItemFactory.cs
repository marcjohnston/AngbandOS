namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class CommonPrayerLifeBookItemFactory : LifeBookItemFactory
    {
        private CommonPrayerLifeBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "[Book of Common Prayer]";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Book of Common Prayer]";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 0;
        public override int Weight => 30;
        public override bool KindIsGood => false;
        public override Item CreateItem() => new CommonPrayerLifeBookItem(SaveGame);

        public override Spell[] Spells => new Spell[]
        {
            SaveGame.SingletonRepository.Spells.Get<LifeSpellDetectEvil>(),
            SaveGame.SingletonRepository.Spells.Get<LifeSpellCureLightWounds>(),
            SaveGame.SingletonRepository.Spells.Get<LifeSpellBless>(),
            SaveGame.SingletonRepository.Spells.Get<LifeSpellRemoveFear>(),
            SaveGame.SingletonRepository.Spells.Get<LifeSpellCallLight>(),
            SaveGame.SingletonRepository.Spells.Get<LifeSpellDetectTrapsAndSecretDoors>(),
            SaveGame.SingletonRepository.Spells.Get<LifeSpellCureMediumWounds>(),
            SaveGame.SingletonRepository.Spells.Get<LifeSpellSatisfyHunger>()
       };

    }
}
