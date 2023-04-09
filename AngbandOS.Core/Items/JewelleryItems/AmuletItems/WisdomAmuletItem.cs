namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WisdomAmuletItem : AmuletItem
    {
        public WisdomAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletWisdom>()) { }
    }
}