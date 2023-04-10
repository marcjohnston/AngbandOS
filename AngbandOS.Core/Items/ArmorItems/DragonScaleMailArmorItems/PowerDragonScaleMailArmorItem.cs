namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PowerDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public PowerDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PowerDragonScaleMailArmorItemFactory>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe the elements (300) every 300+d300 turns";
        }
    }
}