namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SummonMonsterScrollItem : ScrollItem
    {
        public SummonMonsterScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScrollSummonMonster>()) { }
    }
}