// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ChestTraps;

internal class ActivateChestTrapEventArgs
{
    /// <summary>
    /// Returns a reference to the save game so that the trap has access to the entire game structure.
    /// </summary>
    public SaveGame SaveGame { get; }

    /// <summary>
    /// Returns the X grid position of trap.
    /// </summary>
    public int X { get; }

    /// <summary>
    /// Returns the Y grid position of the trap.
    /// </summary>
    public int Y { get; }

    /// <summary>
    /// Returns whether or not the activation of the trap destroys the contents.  Returns false, by default.  Set to true, when the trap destroys the contents.
    /// </summary>
    public bool DestroysContents = false;

    public ActivateChestTrapEventArgs(SaveGame saveGame, int x, int y)
    {
        SaveGame = saveGame;
        X = x;
        Y = y;
    }
}
