namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LargeIronChestItem : ChestItem
    {
        public LargeIronChestItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ChestLargeIron>()) { }
    }
}