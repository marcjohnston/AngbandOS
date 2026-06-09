// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal class GameRandom
{
    private IRandomGenerator randomGenerator;

    public GameRandom()
    {
        randomGenerator = new SystemRng();
    }

    public GameRandom(int seed)
    {
        randomGenerator = new SystemRng(seed);
    }

    /// <summary>
    /// Generates a random number less than the max value.  The max value must be greater than 0.
    /// </summary>
    /// <param name="max"> </param>
    /// <returns> </returns>
    public int Next(int max)
    {
        if (max < 0)
        {
            throw new Exception("DEBUG ... this shouldn't happen");
           //return 0; // TODO: This defies the stated purpose
        }
        return randomGenerator.Next(max);
    }
    public double NextDouble()
    {
        return randomGenerator.NextDouble();
    }
}
