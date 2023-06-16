// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal class PageStoreCommand : BaseStoreCommand
{
    private PageStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char Key => ';';

    public override string Description => "scroll ";

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        int dir = SaveGame.CommandDirection;
        while (dir == 0)
        {
            if (!SaveGame.GetCom("Direction (Escape to cancel)? ", out char ch))
            {
                break;
            }
            dir = SaveGame.GetKeymapDir(ch);
        }
        if (dir == 9)
        {
            storeCommandEvent.Store.PageUp();
        }
        else if (dir == 3)
        {
            storeCommandEvent.Store.PageDown();
        }
    }
}

