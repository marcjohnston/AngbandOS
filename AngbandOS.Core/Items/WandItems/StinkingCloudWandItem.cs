namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StinkingCloudWandItem : WandItem
    {
        public StinkingCloudWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandStinkingCloud>()) { }
    }
}