// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interfaces;

/// <summary>
/// Represents the interface that a class needs to implement to participate in change tracking.  Properties and TimedActions participate in this change tracking.  Widgets need
/// change tracking to determine when the widget is invalid and needs to be repainted.
/// </summary>
internal interface IChangeTracker
{
    /// <summary>
    /// Clear the change tracking flag to indicate that the value has not changed.
    /// </summary>
    void ClearChangedFlag();

    /// <summary>
    /// Returns true, if the value has changed, since the last Clear().
    /// </summary>
    bool IsChanged { get; }
}

