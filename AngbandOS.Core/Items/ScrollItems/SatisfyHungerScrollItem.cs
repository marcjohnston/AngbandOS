namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SatisfyHungerScrollItem : ScrollItem
    {
        public SatisfyHungerScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollSatisfyHunger>()) { }
    }
}