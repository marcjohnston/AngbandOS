namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ResistFireRingItem : RingItem
    {
        public ResistFireRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingResistFire>()) { }
        public override bool EasyKnow => true;
        public override bool IgnoreFire => true;
        public override bool ResFire => true;
    }
}