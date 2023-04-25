namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LargeSteelChestItem : ChestItem
    {
        public LargeSteelChestItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ChestLargeSteel>()) { }
    }
}