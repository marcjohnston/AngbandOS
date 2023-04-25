namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BalanceDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public BalanceDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BalanceDragonScaleMailArmorItemFactory>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "You breathe balance (250) every 300+d300 turns";
        }
    }
}