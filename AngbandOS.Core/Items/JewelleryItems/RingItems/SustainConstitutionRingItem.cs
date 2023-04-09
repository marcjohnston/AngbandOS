namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SustainConstitutionRingItem : RingItem
    {
        public SustainConstitutionRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingSustainConstitution>()) { }
    }
}