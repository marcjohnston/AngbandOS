namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ScrollItem : Item
    {
        public ScrollItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 12;
        public override int PercentageBreakageChance => 50;
        public override bool EasyKnow => true;
    }
}