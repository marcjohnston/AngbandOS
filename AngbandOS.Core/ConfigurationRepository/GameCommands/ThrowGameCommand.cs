﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Commands;

/// <summary>
/// Throw an item
/// </summary>
[Serializable]
internal class ThrowGameCommand : GameCommand
{
    private ThrowGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'v';

    public override bool Execute()
    {
        SaveGame.DoCmdThrow(1);
        return false;
    }
}