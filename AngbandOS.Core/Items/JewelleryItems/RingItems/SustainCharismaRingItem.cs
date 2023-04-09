namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SustainCharismaRingItem : RingItem
    {
        public SustainCharismaRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingSustainCharisma>()) { }
        public override bool EasyKnow => true;
        public override bool SustCha => true;
    }
}