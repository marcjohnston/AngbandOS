namespace AngbandOS.Core.Items
{
[Serializable]
    internal class Gold2GoldItem : GoldItem
    {
        public Gold2GoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<GoldCopper>()) { }
    }
}