﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.GameCommands;

/// <summary>
/// Attempt to disarm a trap on a door or chest
/// </summary>
[Serializable]
internal class DisarmGameCommand : GameCommand
{
    private DisarmGameCommand(Game game) : base(game) { } // This object is a singleton.

    public override char KeyChar => 'D';

    public override int? Repeat => 99;

    protected override string? ExecuteScriptName => nameof(DisarmScript);
}
