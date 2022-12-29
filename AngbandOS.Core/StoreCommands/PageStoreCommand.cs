namespace AngbandOS.Core.StoreCommands
{
    internal class PageStoreCommand : BaseStoreCommand
    {
        public override char Key => ';';

        public override string Description => "scroll ";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            int dir = storeCommandEvent.SaveGame.CommandDirection;
            while (dir == 0)
            {
                if (!storeCommandEvent.SaveGame.GetCom("Direction (Escape to cancel)? ", out char ch))
                {
                    break;
                }
                dir = storeCommandEvent.SaveGame.GetKeymapDir(ch);
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
}

