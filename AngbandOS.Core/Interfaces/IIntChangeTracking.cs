// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Interfaces;

/// <summary>
/// Represents the interface that a class needs to implement to participate in change tracking for an integer value.  This interface adds an Int value signature to the 
/// change trackable interface and is used by DynamicWidgets to render integer values that change.
/// </summary>
internal interface IIntChangeTracking : IChangeTracker
{
    int Value { get; }
}
