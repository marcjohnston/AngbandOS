// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class NoticeReorderFlaggedAction : FlaggedAction
{
    private NoticeReorderFlaggedAction(Game game) : base(game) { }
    protected override void Execute()
    {
        bool itemsWereReordered = SortPack();
        if (itemsWereReordered)
        {
            Game.MsgPrint("You reorder some items in your pack.");
        }
    }
    private bool SortPack()
    {
        PackInventorySlot packInventorySlot = (PackInventorySlot)Game.SingletonRepository.Get<BaseInventorySlot>(nameof(PackInventorySlot));

        // Create a list for all of the pack items.
        List<Item> packItems = new List<Item>();
        foreach (int index in packInventorySlot.InventorySlots)
        {
            Item? item = Game.GetInventoryItem(index);
            if (item != null)
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
                if (Game.GetInventoryItem(index) != packItems[packItemIndex])
                {
                    itemsWereReordered = true;
                }
                Game.SetInventoryItem(index, packItems[packItemIndex]);
                packItemIndex++;
            }
            else
            {
                Game.SetInventoryItem(index, null);
            }
        }
        return itemsWereReordered;
    }

}
