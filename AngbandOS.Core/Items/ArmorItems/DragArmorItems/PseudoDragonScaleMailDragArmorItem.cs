namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PseudoDragonScaleMailDragArmorItem : DragArmorItem
    {
        public PseudoDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorPseudoDragonScaleMail>()) { }
        public override bool Activate => true;
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override bool ResDark => true;
        public override bool ResLight => true;
    }
}