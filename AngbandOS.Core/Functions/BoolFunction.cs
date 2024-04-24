
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Functions;

[Serializable]
internal abstract class BoolFunction : Function, IBoolValue, IConditional
{
    protected BoolFunction(Game game) : base(game) { }

    public abstract bool Value { get; }

    /// <summary>
    /// Returns the boolean result of the function.  This method provides the implementation for the IConditional interface.
    /// </summary>
    public bool IsTrue => Value;
}