namespace AngbandOS.Core.Items
{
[Serializable]
    internal class FireScrollItem : ScrollItem
    {
        public FireScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollFire>()) { }
    }
}