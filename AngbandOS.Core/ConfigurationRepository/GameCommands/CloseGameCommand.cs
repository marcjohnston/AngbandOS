// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Commands;

/// <summary>
/// Close a door
/// </summary>
[Serializable]
internal class CloseGameCommand : GameCommand
{
    private CloseGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char KeyChar => 'c';

    /// <summary>
    /// The close door command is repeatable, until the door is closed.
    /// </summary>
    public override int? Repeat => 99;

    protected override string? ExecuteScriptName => nameof(CloseScript);
}
