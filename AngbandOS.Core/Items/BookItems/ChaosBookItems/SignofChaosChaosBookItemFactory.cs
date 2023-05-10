namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SignOfChaosChaosBookItemFactory : ChaosBookItemFactory
    {
        private SignOfChaosChaosBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "[Sign of Chaos]";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Sign of Chaos]";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 0;
        public override int Weight => 30;
        public override bool KindIsGood => false;

        public override Spell[] Spells => new Spell[]
        {
            SaveGame.SingletonRepository.Spells.Get<ChaosSpellMagicMissile>(),
            SaveGame.SingletonRepository.Spells.Get<ChaosSpellTrapAndDoorDestruction>(),
            SaveGame.SingletonRepository.Spells.Get<ChaosSpellFlashOfLight>(),
            SaveGame.SingletonRepository.Spells.Get<ChaosSpellTouchOfConfusion>(),
            SaveGame.SingletonRepository.Spells.Get<ChaosSpellManaBurst>(),
            SaveGame.SingletonRepository.Spells.Get<ChaosSpellFireBolt>(),
            SaveGame.SingletonRepository.Spells.Get<ChaosSpellFistOfForce>(),
            SaveGame.SingletonRepository.Spells.Get<ChaosSpellTeleportSelf>()
        };

        public override Item CreateItem() => new SignOfChaosChaosBookItem(SaveGame);
    }
}
