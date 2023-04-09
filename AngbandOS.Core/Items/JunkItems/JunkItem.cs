namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class JunkItem : Item
    {
        public JunkItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 38;
        public override int PercentageBreakageChance => 100;
        public override bool EasyKnow => true;
    }
}