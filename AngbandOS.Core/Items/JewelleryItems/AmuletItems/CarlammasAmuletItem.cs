namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CarlammasAmuletItem : AmuletItem
    {
        public CarlammasAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletCarlammas>()) { }
    }
}