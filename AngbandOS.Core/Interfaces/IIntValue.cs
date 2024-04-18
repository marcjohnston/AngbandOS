// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Interfaces;

/// <summary>
/// Represents an interface for an object to implement for it to participate in returning an Integer value.
/// </summary>
internal interface IIntValue
{
    int IntValue { get; }
}

