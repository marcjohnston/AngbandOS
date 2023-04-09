namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AggravateMonsterRingItem : RingItem
    {
        public AggravateMonsterRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingAggravateMonster>()) { }
        public override bool Aggravate => true;
        public override bool EasyKnow => true;
        public override bool Cursed => true;
    }
}