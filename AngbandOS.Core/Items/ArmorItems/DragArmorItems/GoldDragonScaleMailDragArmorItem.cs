namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GoldDragonScaleMailDragArmorItem : DragArmorItem
    {
        public GoldDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorGoldDragonScaleMail>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe sound (130) every 450+d450 turns";
        }
    }
}