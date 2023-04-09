namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BalanceDragonScaleMailDragArmorItem : DragArmorItem
    {
        public BalanceDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorBalanceDragonScaleMail>()) { }
        public override bool Activate => true;
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override bool ResChaos => true;
        public override bool ResDisen => true;
        public override bool ResShards => true;
        public override bool ResSound => true;
    }
}