namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ArrowAmmunitionItem : AmmunitionItem
    {
        public override int PackSort => 34;
        public ArrowAmmunitionItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override bool GetsDamageMultiplier => true;
        public override int MakeObjectCount => Program.Rng.DiceRoll(6, 7);

        public override int PercentageBreakageChance => 25;
        public override bool ShowMods => true;
    }
}