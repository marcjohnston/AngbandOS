namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WonderWandItem : WandItem
    {
        public WonderWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandWonder>()) { }
    }
}