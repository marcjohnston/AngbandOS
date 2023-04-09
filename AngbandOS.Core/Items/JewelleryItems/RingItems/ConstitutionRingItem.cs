namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ConstitutionRingItem : RingItem
    {
        public ConstitutionRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingConstitution>()) { }
        public override bool Con => true;
        public override bool HideType => true;
    }
}