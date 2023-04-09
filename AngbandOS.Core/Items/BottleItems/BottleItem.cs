namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BottleItem : Item
    {
        public BottleItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 39;
        public override int PercentageBreakageChance => 100;
        public override bool EasyKnow => true;
    }
}