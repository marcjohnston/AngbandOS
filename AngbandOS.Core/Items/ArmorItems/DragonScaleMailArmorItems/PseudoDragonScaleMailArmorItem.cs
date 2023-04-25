namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PseudoDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public PseudoDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PseudoDragonScaleMailArmorItemFactory>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe light/darkness (200) every 300+d300 turns";
        }
    }
}