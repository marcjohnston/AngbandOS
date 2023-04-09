namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AntiTheftAmuletItem : AmuletItem
    {
        public AntiTheftAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletAntiTheft>()) { }
        public override bool AntiTheft => true;
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}