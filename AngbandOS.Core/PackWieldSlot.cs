// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class PackWieldSlot : WieldSlot
{
    protected const string alphabet = "abcdefghijklmnopqrstuvwxyz";
    private PackWieldSlot(Game game) : base(game) { }
    public override int[] InventorySlots => new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }; // TODO: Is 26 valid?  Game.InvenCarry says otherwise
    public override int MaximumItemSlots => InventorySlots.Length;
    public override string Label(Item oPtr)
    {
        int foundSlot = FindInventorySlot(oPtr);
        return alphabet[foundSlot].ToString();
    }
    public override string MentionUse(int? index) => "In pack";
    public override string SenseLocation(Item item) => "in your pack";
    public override int SortOrder => 0;

    public override string DescribeItemLocation(Item oPtr) => "carrying in your pack";

    public override void AddItem(Item oPtr) // TODO: this doesn't support the multi-item slots
    {
        Game.InventoryCarry(oPtr);
    }

    /// Checks the quantity of an item and removes it, when the quantity is zero.  The pack inventory slot will move subsequent items in the pack to the end of the pack.
    /// </summary>
    /// <param name="oPtr"></param>
    public override void ItemOptimize(Item oPtr)
    {
        // Check to see if there are any items remaining.
        if (oPtr.StackCount > 0)
        {
            // There are, nothing to do.
            return;
        }

        // Remove the item from the inventory slot.
        int foundSlot = FindInventorySlot(oPtr);
        Game._invenCnt--;
        for (int i = foundSlot; i < InventorySlotEnum.PackCount; i++)
        {
            Game.SetInventoryItem(i, Game.GetInventoryItem(i + 1));
        }
        Game.SetInventoryItem(InventorySlotEnum.PackCount, null);
    }

    public override bool IsWieldedAsEquipment => false;

    /// <summary>
    /// Returns true, to sense the identity of items in the pack only 20% of the time.
    /// </summary>
    public override bool IdentitySenseChanceTest => Game.RandomLessThan(5) == 0;

    /// <summary>
    /// Allows items being carried in a pack to hook into the ProcessWorld event.  By default, this method initiates the hook for all items in the inventory slot to perform processing 
    /// during the ProcessWorld event through the PackProcessWorld method.
    /// </summary>
    public override void ProcessWorld(ProcessWorldEventArgs processWorldEventArgs)
    {
        base.ProcessWorld(processWorldEventArgs);

        foreach (int index in InventorySlots)
        {
            Item? oPtr = Game.GetInventoryItem(index);
            if (oPtr != null)
            {
                oPtr.PackProcessWorld();
            }
        }
    }
}