namespace AngbandOS.Core.Items
{
[Serializable]
    internal class NecklaceAmuletItem : AmuletItem
    {
        public NecklaceAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AmuletNecklace>()) { }
    }
}