﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.GameCommands;

/// <summary>
/// Spend a turn searching for traps and secret doors
/// </summary>
[Serializable]
internal class SearchGameCommand : GameCommand
{
    private SearchGameCommand(Game game) : base(game) { } // This object is a singleton.

    public override char KeyChar => 's';

    public override int? Repeat => null;

    protected override string? ExecuteScriptName => nameof(SearchScript);
}
