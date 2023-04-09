namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AdornmentAmuletItem : AmuletItem
    {
        public AdornmentAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletAdornment>()) { }
    }
}