namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WhiteDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public WhiteDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WhiteDragonScaleMailArmorItemFactory>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe frost (110) every 450+d450 turns";
        }
    }
}