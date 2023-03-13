namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SoundResistanceRingItem : RingItem
    {
        public SoundResistanceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingSoundResistance>()) { }
    }
}