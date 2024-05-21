// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Rolls;

internal class DieRoll : Roll
{
    public DieRoll(Game game, int dieCount, int sideCount, int multiplier, int bonus) : this(game, dieCount, sideCount, multiplier, bonus, false) { }
    public DieRoll(Game game, int dieCount, int sideCount, int multiplierOrDivisor, int bonus, bool multiplierIsDivisor) : base(game)
    {
        if (dieCount == 0)
        {
            throw new Exception("Die count cannot be 0.");
        }
        if (multiplierOrDivisor == 0)
        {
            throw new Exception("Die roll multiplier cannot be 0.");
        }
        QuantityDice = dieCount;
        SideCount = sideCount;
        MultiplierIsDivisor = true;
        Multiplier = multiplierOrDivisor;
        Bonus = bonus;
    }
    public int QuantityDice { get; }
    public int SideCount { get; }
    public bool MultiplierIsDivisor { get; }
    public int Multiplier { get; }
    public int Bonus { get; }
    public override int Get(Random random)
    {
        int sum = 0;
        for (int i = 0; i < QuantityDice; i++)
        {
            int roll = random.Next(SideCount) + 1;
            sum += roll;
        }
        if (MultiplierIsDivisor)
        {
            return sum / Multiplier + Bonus;
        }
        return sum * Multiplier + Bonus;
    }
}
