namespace AngbandOS.Core.Items
{
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
        /// Returns true, if the container is part of the players inventory.
        /// </summary>
        bool IsInInventory { get; }
    }
}
