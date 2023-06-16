namespace AngbandOS.Core.Items;

[Serializable]
internal class FearResistanceRingItem : RingItem
{
    public FearResistanceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<FearResistanceRingItemFactory>()) { }
}