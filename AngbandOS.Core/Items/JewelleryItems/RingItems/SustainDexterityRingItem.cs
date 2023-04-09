namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SustainDexterityRingItem : RingItem
    {
        public SustainDexterityRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingSustainDexterity>()) { }
        public override bool EasyKnow => true;
        public override bool SustDex => true;
    }
}