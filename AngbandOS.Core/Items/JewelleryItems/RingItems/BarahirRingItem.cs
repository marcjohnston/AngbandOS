namespace AngbandOS.Core.Items;

[Serializable]
internal class BarahirRingItem : RingItem
{
    public BarahirRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BarahirRingItemFactory>()) { }
}