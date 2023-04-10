namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GreenDragonScaleMailDragArmorItem : DragArmorItem
    {
        public GreenDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorGreenDragonScaleMail>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe poison gas (150) every 450+d450 turns";
        }
    }
}