namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ResistColdRingItem : RingItem
    {
        public ResistColdRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingResistCold>()) { }
        public override bool EasyKnow => true;
        public override bool IgnoreCold => true;
        public override bool ResCold => true;
    }
}