namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class NoticeReorderFlaggedAction : FlaggedAction
    {
        public NoticeReorderFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            PackInventorySlot packInventorySlot = SaveGame.SingletonRepository.InventorySlots.Get<PackInventorySlot>();

            // Create a list for all of the pack items.
            List<Item> packItems = new List<Item>();
            foreach (int index in packInventorySlot.InventorySlots)
            {
                Item item = SaveGame.Player.Inventory[index];
                if (item.BaseItemCategory != null)
                {
                    packItems.Add(item);
                }
            }

            // Sort the pack.
            packItems.Sort();

            // Reinsert the items back into the inventory.
            bool itemsWereReordered = false;
            int packItemIndex = 0;
            foreach (int index in packInventorySlot.InventorySlots)
            {
                if (packItemIndex < packItems.Count)
                {
                    if (SaveGame.Player.Inventory[index] != packItems[packItemIndex])
                    {
                        itemsWereReordered = true;
                    }
                    SaveGame.Player.Inventory[index] = packItems[packItemIndex];
                    packItemIndex++;
                } 
                else
                {
                    SaveGame.Player.Inventory[index] = new Item(SaveGame);
                }
            }

            //for (int i = 0; i < InventorySlot.PackCount; i++)
            //{
            //    Item oPtr = SaveGame.Player.Inventory[i];

            //    // Ensure it is not an empty slot.
            //    if (oPtr.BaseItemCategory != null)
            //    {
            //        // Compute the value (only once).
            //        int j;
            //        for (j = 0; j < i; j++)
            //        {
            //            Item jPtr = SaveGame.Player.Inventory[j];
            //            if (jPtr.SlotsBefore(oPtr))
            //            {
            //                itemsWereReordered = true;
            //                Item qPtr = SaveGame.Player.Inventory[i];
            //                for (int k = i; k > j; k--)
            //                {
            //                    SaveGame.Player.Inventory[k] = SaveGame.Player.Inventory[k - 1];
            //                }
            //                SaveGame.Player.Inventory[j] = qPtr;
            //            }
            //        }
            //    }
            //}
            if (itemsWereReordered)
            {
                SaveGame.MsgPrint("You reorder some items in your pack.");
            }
        }
    }
}
