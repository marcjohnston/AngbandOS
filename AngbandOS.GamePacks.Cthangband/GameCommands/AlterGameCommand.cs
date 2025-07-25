﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Alter a tile in a 'sensibe' way given the tile type
/// </summary>
/// <exception cref="ArgumentOutOfRangeException"> </exception>
[Serializable]
public class AlterGameCommand : GameCommandGameConfiguration
{
    public override char KeyChar => '+';

    public override int? Repeat => 99;

    public override string? ExecuteScriptName => nameof(SystemScriptsEnum.AlterScript);
}
