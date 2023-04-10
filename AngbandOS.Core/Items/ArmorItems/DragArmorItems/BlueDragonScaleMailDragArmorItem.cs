namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BlueDragonScaleMailDragArmorItem : DragArmorItem
    {
        public BlueDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorBlueDragonScaleMail>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe lightning (100) every 450+d450 turns";
        }
    }
}