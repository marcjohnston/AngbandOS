namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SpecialIdentifyScrollItem : ScrollItem
    {
        public SpecialIdentifyScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollSpecialIdentify>()) { }
    }
}