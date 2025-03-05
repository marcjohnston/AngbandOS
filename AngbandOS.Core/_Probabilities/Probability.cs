// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Probabilities;

[Serializable]
internal class Probability
{
    private readonly Game Game;
    private Expression _expression { get; }
    public Probability(Game game, Expression expression)
    {
        Game = game;
        _expression = expression;
    }

    /// <summary>
    /// Computes the expression, ensures and returns the result of the expression being an integer value between and including both 0 and 100.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public double GetPercentage()
    {
        // Compute the expression value.  Integer expressions can be converted to decimals.
        return Game.ComputeDecimalExpression(_expression).Value;
    }

    /// <summary>
    /// Returns true, if a random test succeeds.
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    public bool Test()
    {
        double percentage = GetPercentage() * 100;
        return Game.DieRoll(100) < (int)percentage;
    }
}
