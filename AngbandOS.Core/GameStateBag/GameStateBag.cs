// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Base type for a serialized piece of game state.
/// </summary>
internal abstract class GameStateBag
{
    /// <summary>
    /// Verifies that this <see cref="GameStateBag"/> is valid in the context of a restore operation.
    /// </summary>
    /// <param name="restoreGameState">
    /// The <see cref="RestoreGameState"/> instance that is performing the verification. Implementations
    /// can use this to access context, object tables, or other state required to validate references
    /// and nested values.
    /// </param>
    /// <param name="singleton">
    /// Optional singleton instance associated with this bag during restore. May be <c>null</c>.
    /// The meaning of this parameter depends on the concrete <see cref="GameStateBag"/> implementation.
    /// </param>
    /// <returns>
    /// <c>true</c> when the bag is in a valid state for restore; otherwise <c>false</c>.
    /// </returns>
    /// <remarks>
    /// The default implementation returns <c>true</c>. Override this method in derived types to
    /// perform type-specific validation (for example: ensuring referenced object IDs exist, types
    /// match expectations, required fields are present, or array lengths are valid).
    /// </remarks>
    public virtual bool Verify(RestoreGameState restoreGameState, object? singleton) => true;
}
