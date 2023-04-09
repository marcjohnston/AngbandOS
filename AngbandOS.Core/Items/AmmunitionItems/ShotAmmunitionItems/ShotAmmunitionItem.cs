namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ShotAmmunitionItem : AmmunitionItem
    {
        public ShotAmmunitionItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 35;
        public override bool GetsDamageMultiplier => true;
        public override int MakeObjectCount => Program.Rng.DiceRoll(6, 7);

        public override int PercentageBreakageChance => 25;
    }
}