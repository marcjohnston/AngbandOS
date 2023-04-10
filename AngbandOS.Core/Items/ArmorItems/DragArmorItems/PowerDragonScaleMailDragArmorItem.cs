namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PowerDragonScaleMailDragArmorItem : DragArmorItem
    {
        public PowerDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorPowerDragonScaleMail>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe the elements (300) every 300+d300 turns";
        }
    }
}