// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Commands;

/// <summary>
/// Take off an item
/// </summary>
[Serializable]
internal class TakeOffGameCommand : GameCommand
{
    private TakeOffGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 't';

    public override bool Execute()
    {
        SaveGame.RunScript<TakeOffScript>();
        return false;
    }
}
