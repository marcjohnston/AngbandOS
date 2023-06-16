namespace AngbandOS.Core.Items;

[Serializable]
internal class AggravateMonsterScrollItem : ScrollItem
{
    public AggravateMonsterScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScrollAggravateMonster>()) { }
}