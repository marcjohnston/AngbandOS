namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GreenDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public GreenDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<GreenDragonScaleMailArmorItemFactory>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe poison gas (150) every 450+d450 turns";
        }
    }
}