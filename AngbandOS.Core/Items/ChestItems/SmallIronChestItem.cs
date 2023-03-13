namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SmallIronChestItem : ChestItem
    {
        public SmallIronChestItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ChestSmallIron>()) { }
    }
}