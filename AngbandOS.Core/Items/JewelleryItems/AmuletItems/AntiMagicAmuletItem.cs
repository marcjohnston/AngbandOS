namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AntiMagicAmuletItem : AmuletItem
    {
        public AntiMagicAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletAntiMagic>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override bool NoMagic => true;
    }
}