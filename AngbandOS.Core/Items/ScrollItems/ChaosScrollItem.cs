namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ChaosScrollItem : ScrollItem
    {
        public ChaosScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollChaos>()) { }
    }
}