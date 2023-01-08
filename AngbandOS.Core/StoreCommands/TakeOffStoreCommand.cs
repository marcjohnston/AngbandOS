namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Take off an item
    /// </summary>
    [Serializable]
    internal class TakeOffStoreCommand : BaseStoreCommand
    {
        public override char Key => 't';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            DoCmdTakeOff(storeCommandEvent.SaveGame);
        }

        public static void DoCmdTakeOff(SaveGame saveGame)
        {
            // Get the item to take off
            if (!saveGame.GetItem(out int itemIndex, "Take off which item? ", true, false, false, null))
            {
                if (itemIndex == -2)
                {
                    saveGame.MsgPrint("You are not wearing anything to take off.");
                }
                return;
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex]; // TODO: Remove access to Level
            // Can't take of cursed items
            if (item.IsCursed())
            {
                saveGame.MsgPrint("Hmmm, it seems to be cursed.");
                return;
            }
            // Take off the item
            saveGame.EnergyUse = 50;
            saveGame.Player.InvenTakeoff(itemIndex, 255);
            saveGame.PrEquippyRedrawAction.Set();
        }
    }
}
