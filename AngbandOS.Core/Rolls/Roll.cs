// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Rolls;

[Serializable]
internal abstract class Roll // TODO: We need to add a description for Activations to render
{
    protected readonly Game Game;
    protected Roll(Game game)
    {
        Game = game;
    }

    public abstract int Get(Random random);

    /// <summary>
    /// Returns the maximum value of any possible roll.  This maximum value is used to sort gold item factories
    /// from least to most during the <see cref="Game.MakeGold"/> method.
    /// </summary>
    public int MaximumValue { get; protected set; }

    public abstract string Expression { get; }
    public override string ToString()
    {
        return Expression;
    }
}
