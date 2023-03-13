namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MonsterConfusionScrollItem : ScrollItem
    {
        public MonsterConfusionScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollMonsterConfusion>()) { }
    }
}