﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Select a target in advance for attacks. Note that this does not cost any in-game time
/// </summary>
[Serializable]
public class TargetGameCommand : GameCommandGameConfiguration
{
    public override char KeyChar => '*';

    public override string? ExecuteScriptName => nameof(SystemScriptsEnum.TargetScript);
}
