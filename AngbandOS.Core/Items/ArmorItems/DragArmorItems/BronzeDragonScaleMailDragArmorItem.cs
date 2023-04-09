namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BronzeDragonScaleMailDragArmorItem : DragArmorItem
    {
        public BronzeDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorBronzeDragonScaleMail>()) { }
        public override bool Activate => true;
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override bool ResConf => true;
    }
}