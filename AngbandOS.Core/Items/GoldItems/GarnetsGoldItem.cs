namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GarnetsGoldItem : GoldItem
    {
        public GarnetsGoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<GoldGarnets>()) { }
    }
}