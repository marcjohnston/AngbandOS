// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interfaces;

/// <summary>
/// Represents the interface required for objects to participate as a container for items.  GridTiles, InventorySlots and monsters are item containers.
/// </summary>
internal interface IItemContainer
{
    /// <summary>
    /// Modifies the quantity of an item.  The modification process differs depending on the type of container containing the item (e.g. wield slots will update the player stats, monster and grid tile containers do not).
    /// </summary>
    /// <param name="oPtr"></param>
    /// <param name="num"></param>
    void ModifyItemStackCount(Item oPtr, int num);

    /// <summary>
    /// Returns a description of the item as it is in the container.  For a wield slot, the description is rendered as possessive; non-wield slots, render as the player is viewing the item.
    /// </summary>
    /// <param name="item"></param>
    string DescribeContainer(Item oPtr);

    /// <summary>
    /// Checks the quantity of an item and removes it, when the quanity is zero.  This process differs depending on which container is containing the item.
    /// </summary>
    /// <param name="oPtr"></param>
    void ItemOptimize(Item oPtr);

    /// <summary>
    /// Returns true, if the container is part of the players inventory.  All wield slots (pack & equipment), return true; monsters and grid tiles return false.
    /// </summary>
    bool IsWielded { get; }

    /// <summary>
    /// Returns true, if the container is part of the players wielding/worn equipment.  Equipment wield slots, return true; the pack wield slot, monsters and grid tiles return false.
    /// </summary>
    bool IsWieldedAsEquipment { get; }

    /// <summary>
    /// Returns a description of the location for the item.  An item in the players inventory will return "In your pack", being wielded by the player will return the wield slot wield description,
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

    ///// <summary>
    ///// Adds an item to the container.
    ///// </summary>
    ///// <param name="oPtr"></param>
    //void AddItem(Item oPtr);

    ///// <summary>
    ///// Removed the item from the container.
    ///// </summary>
    ///// <param name="oPtr"></param>
    //void RemoveItem(Item oPtr);
}
