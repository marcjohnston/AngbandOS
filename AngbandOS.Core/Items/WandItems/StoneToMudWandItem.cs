namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StoneToMudWandItem : WandItem
    {
        public StoneToMudWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandStoneToMud>()) { }
    }
}