namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class MasterSorcerersHandbookSorceryBookItemFactory : SorceryBookItemFactory
    {
        private MasterSorcerersHandbookSorceryBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "[Master Sorcerer's Handbook]";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Master Sorcerer's Handbook]";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => 1;
        public override int Weight => 30;
        public override bool KindIsGood => false;
        public override Item CreateItem() => new MasterSorcerersHandbookSorceryBookItem(SaveGame);

        public override Spell[] Spells => new Spell[]
        {
            SaveGame.SingletonRepository.Spells.Get<SorcerySpellMagicMapping>(),
            SaveGame.SingletonRepository.Spells.Get<SorcerySpellIdentify>(),
            SaveGame.SingletonRepository.Spells.Get<SorcerySpellSlowMonster>(),
            SaveGame.SingletonRepository.Spells.Get<SorcerySpellMassSleep>(),
            SaveGame.SingletonRepository.Spells.Get<SorcerySpellTeleportAway>(),
            SaveGame.SingletonRepository.Spells.Get<SorcerySpellHasteSelf>(),
            SaveGame.SingletonRepository.Spells.Get<SorcerySpellDetectionTrue>(),
            SaveGame.SingletonRepository.Spells.Get<SorcerySpellIdentifyTrue>()
        };
    }
}
