// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Close a door
/// </summary>
[Serializable]
public class CloseGameCommand : GameCommandGameConfiguration
{
    public override char KeyChar => 'c';

    /// <summary>
    /// The close door command is repeatable, until the door is closed.
    /// </summary>
    public override int? Repeat => 99;

    public override string? ExecuteScriptName => nameof(SystemScriptsEnum.CloseScript);
}
