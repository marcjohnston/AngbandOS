namespace AngbandOS.Core.Items;

[Serializable]
internal class SlowMonsterRodItem : RodItem
{
    public SlowMonsterRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RodSlowMonster>()) { }
}