namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DamageRingItem : RingItem
    {
        public DamageRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingDamage>()) { }
    }
}