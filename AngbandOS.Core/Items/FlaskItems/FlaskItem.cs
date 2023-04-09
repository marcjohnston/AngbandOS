namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class FlaskItem : Item
    {
        public FlaskItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 10;
        public override int PercentageBreakageChance => 100;
    }
}