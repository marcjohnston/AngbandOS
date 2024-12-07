// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Probabilities;

[Serializable]
internal class PercentProbability : Probability
{
    private int _percent { get; }
    public PercentProbability(int percent)
    {
        if (percent < 0 || percent > 100)
        {
            throw new Exception("Invalid percent expression.  Must be between 0 and 1.");
        }
        _percent = percent;
    }
    public override int Percentage => _percent;
    public override bool Test(Game game) => game.DieRoll(100) <= _percent;
}
