namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LargeWoodenChestItem : ChestItem
    {
        public LargeWoodenChestItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ChestLargeWooden>()) { }
    }
}