namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RedDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public RedDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RedDragonScaleMailArmorItemFactory>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe fire (200) every 450+d450 turns";
        }
    }
}