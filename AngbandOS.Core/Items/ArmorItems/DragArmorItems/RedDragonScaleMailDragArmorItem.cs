namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RedDragonScaleMailDragArmorItem : DragArmorItem
    {
        public RedDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorRedDragonScaleMail>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe fire (200) every 450+d450 turns";
        }
    }
}