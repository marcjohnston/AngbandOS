// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

/// <summary>
/// Represents an interface for an object to implement when it exposes a <see cref="ToString"/> method that is used for debugging purposes.  An object that implements this interface
/// indicates that the u<see cref="ToString"/> method is only used for debugging purposes and not for the game functionality.
/// </summary>
internal interface IDebugDescription
{
    public string DebugDescription { get; }
}