// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Commands;

/// <summary>
/// Fire the missile weapon we have in our hand
/// </summary>
[Serializable]
internal class FireGameCommand : GameCommand
{
    private FireGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char KeyChar => 'f';

    public override bool Execute()
    {
        return SaveGame.RunScript(nameof(FireScript));
    }
}
