namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RemoveCurseScrollItem : ScrollItem
    {
        public RemoveCurseScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollRemoveCurse>()) { }
    }
}