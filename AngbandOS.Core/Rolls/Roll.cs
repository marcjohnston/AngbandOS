// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.RegularExpressions;

namespace AngbandOS.Core.Rolls;

internal abstract class Roll
{
    protected readonly Game Game;
    protected Roll(Game game)
    {
        Game = game;
    }

    public abstract int Get(Random random);

    /// <summary>
    /// Returns a Roll object from a string notation.  The syntax supports both integer and dice-notation formats.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="syntax">
    /// Valid format:
    /// AdXxC+B
    /// where:
    /// A, X and B are integers; when specified
    /// A >= 1; if omitted, defaults to 1
    /// X >= 2
    /// B can be negative and defaults to 0; when omitted
    /// </param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static Roll Parse(Game game, string syntax)
    {
        // Test for simple integer value.
        if (int.TryParse(syntax, out int value))
        {
            return new ValueRoll(game, value);
        }

        // Parse dice notation AdXxC+B.
        syntax = syntax.ToLower();
        int dPos = syntax.IndexOf('d');
        if (dPos == -1)
        {
            throw new Exception("Invalid roll syntax.");
        }

        // We will use a Regex for pattern matching.
        Regex regEx = new Regex(@"(\d*)d(\d+)((x|/)(\d+))?((\+|-)(\d*))?");
        Match match = regEx.Match(syntax);

        // The entire syntax must match.
        if (syntax != match.Groups[0].Value)
        {
            throw new Exception($"Invalid number roll syntax {syntax}.");
        }

        // Extract the matches that we are interested in.
        string dieCountMatch = match.Groups[1].Value;
        string sidesCountMatch = match.Groups[2].Value;
        string multiplierOrDivisorMatch = match.Groups[4].Value;
        string multiplierMatch = match.Groups[5].Value;
        string bonusMatch = match.Groups[6].Value;

        // Ensure integer values.  Actually the regex is already ensuring digits, but we do have a bit-length limit to check.
        if (!int.TryParse(dieCountMatch, out int dieCount))
        {
            throw new Exception($"Invalid number roll syntax {dieCountMatch}.");
        }
        if (!int.TryParse(sidesCountMatch, out int sidesCount))
        {
            throw new Exception($"Invalid max roll syntax {sidesCountMatch}.");
        }
        bool multiplierIsDivision = false;
        int multiplier = 1;
        if (multiplierMatch != "")
        {
            if (!int.TryParse(multiplierMatch, out multiplier))
            {
                throw new Exception($"Invalid multiplier roll syntax {multiplierMatch}.");
            }

            if (multiplierOrDivisorMatch == "/")
            {
                multiplierIsDivision = true;
            }
        }
        int bonus = 0;
        if (bonusMatch != "")
        {
            if (!int.TryParse(bonusMatch, out bonus))
            {
                throw new Exception($"Invalid bonus roll syntax {bonusMatch}.");
            }
        }

        return new DieRoll(game, dieCount, sidesCount, multiplier, bonus, multiplierIsDivision);
    }
}
