﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Rest for either a fixed amount of time or until back to max health and mana
/// </summary>
[Serializable]
public class RestGameCommand : GameCommandGameConfiguration
{
    public override char KeyChar => 'R';

    public override string? ExecuteScriptName => nameof(SystemScriptsEnum.RestInPlaceScript);
}
