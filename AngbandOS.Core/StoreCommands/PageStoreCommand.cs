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

