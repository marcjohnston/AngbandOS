// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Rolls;

[Serializable]
internal class OrdinalMultiplierDiceRoll : Roll
{
    public OrdinalMultiplierDiceRoll(Game game, int dieCount, int sideCount, int multiplier, int bonus) : base(game)
    {
        if (dieCount == 0)
        {
            throw new Exception("Die count cannot be 0.");
        }
        if (multiplier == 0)
        {
            throw new Exception("Die roll multiplier cannot be 0.");
        }
        DieCount = dieCount;
        SideCount = sideCount;
        Multiplier = multiplier;
        Bonus = bonus;
        MaximumValue = DieCount * SideCount * Multiplier + Bonus;
    }
    public int DieCount { get; }
    public int SideCount { get; }
    public int Multiplier { get; }
    public int Bonus { get; }
    public override int Get(Random random)
    {
        int sum = 0;
        for (int i = 0; i < DieCount; i++)
        {
            int roll = random.Next(SideCount) + 1;
            sum += roll;
        }
        sum = sum * Multiplier + Bonus;
        if (sum < 0)
        {
            throw new Exception("Invalid roll syntax produced value less than zero.");
        }
        return sum;
    }
    public override string Expression
    {
        get
        {
            if (Bonus > 0)
            {
                return $"{DieCount}d{SideCount}*{Multiplier}+{Bonus}";
            }
            return $"{DieCount}d{SideCount}*{Multiplier}";
        }
    }
}
