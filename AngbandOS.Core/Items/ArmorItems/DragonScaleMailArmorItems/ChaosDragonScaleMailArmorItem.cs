namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ChaosDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public ChaosDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ChaosDragonScaleMailArmorItemFactory>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe chaos/disenchant (220) every 300+d300 turns";
        }
    }
}