// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.EventArgs;

internal class AlterEventArgs
{
    /// <summary>
    /// Return true, if the command can be continued; false, if the command succeeded or is futile and should not be repeated.
    /// </summary>
    public bool More = false;

    /// <summary>
    /// Returns the x-coordinate of the player.
    /// </summary>
    public int X { get; }

    /// <summary>
    /// Returns the y-coordinate of the player.
    /// </summary>
    public int Y { get; }

    public AlterEventArgs(int y, int x)
    {
        X = x;
        Y = y;
    }
}
