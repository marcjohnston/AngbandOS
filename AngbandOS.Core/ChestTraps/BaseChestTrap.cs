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
