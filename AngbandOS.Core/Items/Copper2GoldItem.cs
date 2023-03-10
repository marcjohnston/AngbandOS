namespace AngbandOS.Core.Items
{
[Serializable]
    internal class Copper2GoldItem : GoldItem
    {
        public Copper2GoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<GoldCopper>()) { }
    }
}