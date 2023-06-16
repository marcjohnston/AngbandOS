namespace AngbandOS.Core.Items;

[Serializable]
internal class DisenchantmentResistanceRingItem : RingItem
{
    public DisenchantmentResistanceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<DisenchantmentResistanceRingItemFactory>()) { }
}