using Cthangband.Commands;
using Cthangband.StaticData;
using System;

namespace Cthangband.StoreCommands
{
    /// <summary>
    /// Examine an item from the player's inventory
    /// </summary>
    [Serializable]
    internal class ExamineInventoryStoreCommand : IStoreCommand
    {
        public char Key => 'I';

        public string Description => "";

        public bool RequiresRerendering => false;

        public bool IsEnabled(Store store) => true;

        public void Execute(SaveGame saveGame, Store store)
        {
            DoCmdExamine(saveGame);
        }

        public static void DoCmdExamine(SaveGame saveGame)
        {
            // Get the item to examine
            if (!saveGame.GetItem(out int itemIndex, "Examine which item? ", true, true, true))
            {
                if (itemIndex == -2)
                {
                    saveGame.MsgPrint("You have nothing to examine.");
                }
                return;
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex]; // TODO: Remove access to Level
            // Do we know anything about it?
            if (item.IdentifyFlags.IsClear(Constants.IdentMental))
            {
                saveGame.MsgPrint("You have no special knowledge about that item.");
                return;
            }
            string itemName = item.Description(true, 3);
            saveGame.MsgPrint($"Examining {itemName}...");
            // We're not actually identifying it, because it's already itentified, but we want to
            // repeat the identification text
            if (!item.IdentifyFully())
            {
                saveGame.MsgPrint("You see nothing special.");
            }
        }
    }
}
