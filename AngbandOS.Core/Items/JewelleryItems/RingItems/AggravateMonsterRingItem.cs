namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AggravateMonsterRingItem : RingItem
    {
        public AggravateMonsterRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingAggravateMonster>()) { }
    }
}