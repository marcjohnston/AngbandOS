namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WhiteDragonScaleMailDragArmorItem : DragArmorItem
    {
        public WhiteDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorWhiteDragonScaleMail>()) { }
        public override bool Activate => true;
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override bool ResCold => true;
    }
}