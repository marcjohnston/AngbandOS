namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BrillianceAmuletItem : AmuletItem
    {
        public BrillianceAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AmuletBrilliance>()) { }
    }
}