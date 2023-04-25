namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SpecialRemoveCurseScrollItem : ScrollItem
    {
        public SpecialRemoveCurseScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScrollSpecialRemoveCurse>()) { }
    }
}