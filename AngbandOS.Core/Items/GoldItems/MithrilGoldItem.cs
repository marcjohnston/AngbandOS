namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MithrilGoldItem : GoldItem
    {
        public MithrilGoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<GoldMithril>()) { }
    }
}