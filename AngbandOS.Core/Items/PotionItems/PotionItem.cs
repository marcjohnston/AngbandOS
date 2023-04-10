namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class PotionItem : Item
    {
        public PotionItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PercentageBreakageChance => 100;
        protected override bool FactoryCanAbsorbItem(Item other)
        {
            return true;
        }
        public override int GetAdditionalMassProduceCount()
        {
            int cost = Value();
            if (cost <= 60)
            {
                return MassRoll(3, 5);
            }
            if (cost <= 240)
            {
                return MassRoll(1, 5);
            }
            return 0;
        }
    }
}