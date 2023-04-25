namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GoldDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public GoldDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GoldDragonScaleMailArmorItemFactory>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe sound (130) every 450+d450 turns";
        }
    }
}