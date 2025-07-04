﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawEquippyFlaggedAction : FlaggedAction
{
    private const int ColEquippy = 0;
    private const int RowEquippy = 13;
    private RedrawEquippyFlaggedAction(Game game) : base(game) { }

    /// <summary>
    /// Display the 'Equippy' characters (the visual representation of a character's equipment)
    /// in the default location on the main game screen
    /// </summary>
    /// <param name="player"> The player whose equippy characters should be displayed </param>
    protected override void Execute()
    {
        Game.DisplayPlayerEquippy(RowEquippy, ColEquippy);
    }
}
