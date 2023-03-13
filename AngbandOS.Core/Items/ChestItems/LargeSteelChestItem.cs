namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LargeSteelChestItem : ChestItem
    {
        public LargeSteelChestItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ChestLargeSteel>()) { }
    }
}