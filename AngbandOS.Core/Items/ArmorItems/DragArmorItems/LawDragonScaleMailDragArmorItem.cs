namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LawDragonScaleMailDragArmorItem : DragArmorItem
    {
        public LawDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorLawDragonScaleMail>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe sound/shards (230) every 300+d300 turns";
        }
    }
}