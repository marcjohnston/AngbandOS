﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Commands;

[Serializable]
internal class WalkWithoutGamePickupCommand : GameCommand
{
    private WalkWithoutGamePickupCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => '-';

    public override int? Repeat => null;

    public override bool Execute()
    {
        SaveGame.DoCmdWalk(true);
        return false;
    }
}