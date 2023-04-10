namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WhiteDragonScaleMailDragArmorItem : DragArmorItem
    {
        public WhiteDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorWhiteDragonScaleMail>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe frost (110) every 450+d450 turns";
        }
    }
}