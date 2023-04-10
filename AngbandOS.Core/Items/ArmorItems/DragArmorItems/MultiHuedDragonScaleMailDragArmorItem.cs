namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MultiHuedDragonScaleMailDragArmorItem : DragArmorItem
    {
        public MultiHuedDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorMultiHuedDragonScaleMail>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe multi-hued (250) every 225+d225 turns";
        }
    }
}