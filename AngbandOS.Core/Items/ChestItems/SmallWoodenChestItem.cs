namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SmallWoodenChestItem : ChestItem
    {
        public SmallWoodenChestItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ChestSmallWooden>()) { }
    }
}