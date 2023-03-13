namespace AngbandOS.Core.Items
{
[Serializable]
    internal class Gold1GoldItem : GoldItem
    {
        public Gold1GoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<GoldGold1>()) { }
    }
}