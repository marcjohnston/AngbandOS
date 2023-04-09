namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BoltAmmunitionItem : AmmunitionItem
    {
        public BoltAmmunitionItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 33;
        public override int MakeObjectCount => Program.Rng.DiceRoll(6, 7);

        public override bool GetsDamageMultiplier => true;
        public override int PercentageBreakageChance => 25;
        public override bool ShowMods => true;
    }
}