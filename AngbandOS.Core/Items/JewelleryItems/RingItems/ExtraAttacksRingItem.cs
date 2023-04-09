namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ExtraAttacksRingItem : RingItem
    {
        public ExtraAttacksRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingExtraAttacks>()) { }
        public override bool Blows => true;
    }
}