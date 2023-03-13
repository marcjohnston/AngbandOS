namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DOOMAmuletItem : AmuletItem
    {
        public DOOMAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletDOOM>()) { }
    }
}