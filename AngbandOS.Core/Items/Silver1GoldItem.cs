namespace AngbandOS.Core.Items
{
[Serializable]
    internal class Silver1GoldItem : GoldItem
    {
        public Silver1GoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<GoldCopper>()) { }
    }
}