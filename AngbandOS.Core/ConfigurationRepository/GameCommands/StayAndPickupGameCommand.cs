﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Commands;

/// <summary>
/// Stand still for a turn and pick up any items
/// </summary>
[Serializable]
internal class StayAndPickupGameCommand : GameCommand
{
    private StayAndPickupGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => ',';

    public override int? Repeat => null;

    public override bool Execute()
    {
        SaveGame.DoCmdStay(true);
        return false;
    }
}