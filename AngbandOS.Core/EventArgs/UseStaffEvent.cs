// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.EventArgs;

internal class UseStaffEvent
{
    /// <summary>
    /// Provided to the staff for access to the entire game structure.  Future version may only limit what the staff has access to.
    /// </summary>
    public SaveGame SaveGame { get; }

    /// <summary>
    /// Returns whether or not the staff was identified after being read.  Returns false, by default.  Set to true, to identify the staff to the player.
    /// </summary>
    public bool Identified { get; set; } = false;

    /// <summary>
    /// Returns whether or not the staff uses a charge.  Returns true, by default.  Set to false, to keep the scroll after being read.
    /// </summary>
    public bool ChargeUsed { get; set; } = true;

    public UseStaffEvent(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }
}
