namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PseudoDragonScaleMailDragArmorItem : DragArmorItem
    {
        public PseudoDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorPseudoDragonScaleMail>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe light/darkness (200) every 300+d300 turns";
        }
    }
}