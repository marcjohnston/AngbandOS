namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BrillianceAmuletItem : AmuletItem
    {
        public BrillianceAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletBrilliance>()) { }
        public override bool HideType => true;
        public override bool Int => true;
        public override bool Wis => true;
    }
}