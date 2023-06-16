// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ChestTraps;

/// <summary>
/// Represents a trap on a chest.  Can be layered with multiple traps.  The base class implements the layering.  Derived classes only
/// need concern themselves with their own implementation and not sub-traps.
/// </summary>
internal abstract class BaseChestTrap
{
    /// <summary>
    /// Activate the trap.
    /// </summary>
    /// <param name="saveGame"></param>
    public abstract void Activate(ActivateChestTrapEventArgs eventArgs);
    public abstract string Description { get; }
}
