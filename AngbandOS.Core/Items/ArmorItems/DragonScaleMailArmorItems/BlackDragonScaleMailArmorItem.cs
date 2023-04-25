namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BlackDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public BlackDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BlackDragonScaleMailArmorItemFactory>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe acid (130) every 450+d450 turns";
        }
    }
}