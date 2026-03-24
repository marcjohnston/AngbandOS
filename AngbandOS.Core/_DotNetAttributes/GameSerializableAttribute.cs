// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

/// <summary>
/// Represents annotation for a field to be serialized.  Properties are not supported--as they may not be read or writable and may trigger execution during read and/or write operations.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public class GameSerializableAttribute : System.Attribute
{
}