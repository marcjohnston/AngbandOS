namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AdamantiteGoldItem : GoldItem
    {
        public AdamantiteGoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<GoldAdamantite>()) { }
    }
}