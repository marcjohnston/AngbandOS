namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BronzeDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public BronzeDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BronzeDragonScaleMailArmorItemFactory>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe confusion (120) every 450+d450 turns";
        }
    }
}