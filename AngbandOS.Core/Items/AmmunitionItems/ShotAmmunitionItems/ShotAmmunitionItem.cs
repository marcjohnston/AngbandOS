// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class ShotAmmunitionItem : AmmunitionItem
{
    public ShotAmmunitionItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    public override bool GetsDamageMultiplier => true;
    public override int MakeObjectCount => Program.Rng.DiceRoll(6, 7);

    public override int PercentageBreakageChance => 25;

    protected override bool FactoryCanAbsorbItem(Item other)
    {
        if (!StatsAreSame(other))
        {
            return false;
        }
        return true;
    }
    public override int GetAdditionalMassProduceCount()
    {
        int cost = Value();
        if (cost <= 5)
        {
            return MassRoll(5, 5);
        }
        if (cost <= 50)
        {
            return MassRoll(5, 5);
        }
        if (cost <= 500)
        {
            return MassRoll(5, 5);
        }
        return 0;
    }
}