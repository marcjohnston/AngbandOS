namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BlindnessResistanceRingItem : RingItem
    {
        public BlindnessResistanceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BlindnessResistanceRingItemFactory>()) { }
    }
}