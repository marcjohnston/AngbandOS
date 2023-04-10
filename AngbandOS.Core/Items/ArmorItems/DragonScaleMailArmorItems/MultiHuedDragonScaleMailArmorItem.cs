namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MultiHuedDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public MultiHuedDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MultiHuedDragonScaleMailArmorItemFactory>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe multi-hued (250) every 225+d225 turns";
        }
    }
}