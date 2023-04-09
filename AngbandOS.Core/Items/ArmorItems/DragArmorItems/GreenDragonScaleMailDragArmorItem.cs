namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GreenDragonScaleMailDragArmorItem : DragArmorItem
    {
        public GreenDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorGreenDragonScaleMail>()) { }
        public override bool Activate => true;
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override bool ResPois => true;
    }
}