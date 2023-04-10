namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BalanceDragonScaleMailDragArmorItem : DragArmorItem
    {
        public BalanceDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorBalanceDragonScaleMail>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "You breathe balance (250) every 300+d300 turns";
        }
    }
}