namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BronzeDragonScaleMailDragArmorItem : DragArmorItem
    {
        public BronzeDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorBronzeDragonScaleMail>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe confusion (120) every 450+d450 turns";
        }
    }
}