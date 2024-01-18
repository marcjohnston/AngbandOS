// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Commands;

/// <summary>
/// Print the version number and build info of the game
/// </summary>
[Serializable]
internal class VersionGameCommand : GameCommand
{
    private VersionGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'V';

    public override bool Execute()
    {
        return SaveGame.RunScript(nameof(VersionScript));
    }
}
