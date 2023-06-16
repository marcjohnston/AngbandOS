namespace AngbandOS.Core.Items;

internal interface IItemContainer
{
    /// <summary>
    /// Modifies the quantity of an item.  The modification process differs depending on the type of container containing the item (e.g. inventory slots will update the player stats, monster and grid tile containers do not).
    /// </summary>
    /// <param name="oPtr"></param>
    /// <param name="num"></param>
    void ItemIncrease(Item oPtr, int num);

    /// <summary>
    /// Renders a description of the item.  For an inventory slot, the description is rendered as possessive; non-inventory slots, render as the player is viewing the item.
    /// </summary>
    /// <param name="item"></param>
    void ItemDescribe(Item oPtr);

    /// <summary>
    /// Checks the quantity of an item and removes it, when the quanity is zero.  This process differs depending on which container is containing the item.
    /// </summary>
    /// <param name="oPtr"></param>
    void ItemOptimize(Item oPtr);

    /// <summary>
    /// Returns true, if the container is part of the players inventory.  All inventory slots (pack & equipment), return true; monsters and grid tiles return false.
    /// </summary>
    bool IsInInventory { get; }

    /// <summary>
    /// Returns true, if the container is part of the players wielding/worn equipment.  Equipment inventory slots, return true; the pack inventory slot, monsters and grid tiles return false.
    /// </summary>
    bool IsInEquipment { get; }

    /// <summary>
    /// Returns a description of the location for the item.  An item in the players inventory will return "In your pack", being wielded by the player will return the inventory slot wield description,
    /// monsters and grid tiles aren't really used yet but location descriptions have been added.
    /// </summary>
    string DescribeItemLocation(Item oPtr);

    /// <summary>
    /// Returns the alphabetical label for the position of the item in the container.  The player will use this label to select the item from the container.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    string Label(Item oPtr);

    /// <summary>
    /// Returns a message to be displayed to the player, when the item is removed from the container.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    string TakeOffMessage(Item oPtr);

    void AddItem(Item oPtr);
    void RemoveItem(Item oPtr);
}
