namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BlessingScrollItem : ScrollItem
    {
        public BlessingScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollBlessing>()) { }
    }
}