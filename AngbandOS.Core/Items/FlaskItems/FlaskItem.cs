namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class FlaskItem : Item
    {
        public FlaskItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PercentageBreakageChance => 100;
        public override int GetAdditionalMassProduceCount()
        {
            int cost = Value();
            if (cost <= 5)
            {
                return MassRoll(3, 5);
            }
            if (cost <= 20)
            {
                return MassRoll(3, 5);
            }
            return 0;
        }
    }
}