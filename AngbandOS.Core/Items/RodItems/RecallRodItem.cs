namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RecallRodItem : RodItem
    {
        public RecallRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RodRecall>()) { }
    }
}