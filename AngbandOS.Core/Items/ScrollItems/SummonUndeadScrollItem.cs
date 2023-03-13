namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SummonUndeadScrollItem : ScrollItem
    {
        public SummonUndeadScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollSummonUndead>()) { }
    }
}