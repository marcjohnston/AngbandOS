namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ChaosDragonScaleMailDragArmorItem : DragArmorItem
    {
        public ChaosDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorChaosDragonScaleMail>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe chaos/disenchant (220) every 300+d300 turns";
        }
    }
}