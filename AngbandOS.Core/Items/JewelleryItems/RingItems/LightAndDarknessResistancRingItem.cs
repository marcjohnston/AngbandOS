namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LightAndDarknessResistancRingItem : RingItem
    {
        public LightAndDarknessResistancRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingLightAndDarknessResistanc>()) { }
    }
}