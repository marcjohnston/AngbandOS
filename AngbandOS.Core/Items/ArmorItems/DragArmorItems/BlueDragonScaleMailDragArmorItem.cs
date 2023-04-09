namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BlueDragonScaleMailDragArmorItem : DragArmorItem
    {
        public BlueDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorBlueDragonScaleMail>()) { }
        public override bool Activate => true;
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override bool ResElec => true;
    }
}