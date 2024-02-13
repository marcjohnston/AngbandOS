// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Flavors;

/// <summary>
/// Represents a flavor for the items that are created by an item factory that participate in the IFlavorFactory interface.
/// </summary>
internal abstract class Flavor
{
    protected SaveGame SaveGame;
    protected Flavor(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    /// Returns the symbol to use for rendering.
    /// </summary>
    public abstract Symbol Symbol { get; }

    /// <summary>
    /// The color to use for the visual.
    /// </summary>
    public virtual ColorEnum Color => ColorEnum.White;

    /// <summary>
    /// A unique identifier for the inscription.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Returns true, if the flavor can be assigned; false, if the flavor shouldn't be assigned during the flavor assignments.  False will be returned for the
    /// apple juice, slime mold juice and water potions because they specify their flavors.
    /// </summary>
    public virtual bool CanBeAssigned => true;

    public override string ToString()
    {
        return Name;
    }
}
