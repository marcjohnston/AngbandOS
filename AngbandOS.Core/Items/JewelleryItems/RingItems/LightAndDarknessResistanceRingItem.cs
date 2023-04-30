namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LightAndDarknessResistanceRingItem : RingItem
    {
        public LightAndDarknessResistanceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<LightAndDarknessResistanceRingItemFactory>()) { }
    }
}