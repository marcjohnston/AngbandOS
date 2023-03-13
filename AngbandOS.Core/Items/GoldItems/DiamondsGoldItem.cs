namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DiamondsGoldItem : GoldItem
    {
        public DiamondsGoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<GoldDiamonds>()) { }
    }
}