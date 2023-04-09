namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LawDragonScaleMailDragArmorItem : DragArmorItem
    {
        public LawDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorLawDragonScaleMail>()) { }
        public override bool Activate => true;
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override bool ResShards => true;
        public override bool ResSound => true;
    }
}