namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SpecialAcquirementScrollItem : ScrollItem
    {
        public SpecialAcquirementScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollSpecialAcquirement>()) { }
    }
}