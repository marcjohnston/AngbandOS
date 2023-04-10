namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LawDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public LawDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<LawDragonScaleMailArmorItemFactory>()) { }
        public override string? FactoryDescribeActivationEffect()
        {
            return "breathe sound/shards (230) every 300+d300 turns";
        }
    }
}