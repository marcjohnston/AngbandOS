namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlowDigestionAmuletItem : AmuletItem
    {
        public SlowDigestionAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AmuletSlowDigestion>()) { }
    }
}