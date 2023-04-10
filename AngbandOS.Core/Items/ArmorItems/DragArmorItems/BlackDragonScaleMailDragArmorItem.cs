namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BlackDragonScaleMailDragArmorItem : DragArmorItem
    {
        public BlackDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorBlackDragonScaleMail>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe acid (130) every 450+d450 turns";
        }
    }
}