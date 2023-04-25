namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BlueDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public BlueDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BlueDragonScaleMailArmorItemFactory>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe lightning (100) every 450+d450 turns";
        }
    }
}