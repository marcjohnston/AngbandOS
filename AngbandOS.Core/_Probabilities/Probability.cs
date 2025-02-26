// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Probabilities;

[Serializable]
internal abstract class Probability
{
    /// <summary>
    /// Returns the percentage the probability will succeed.
    /// </summary>
    public abstract int Percentage { get; }

    /// <summary>
    /// Returns true, if a random test succeeds.
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    public abstract bool Test(Game game);
}
