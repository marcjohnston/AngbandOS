namespace AngbandOS.Core.WeightedRandoms
{
    /// <summary>
    /// Represents a weighted random for inventory slots that represent armour.  Body, head, feet, arms, hands and cloak are
    /// armour inventory slots.
    /// </summary>
    internal class DisenchantInventorySlotWeightedRandom : WeightedRandom<BaseInventorySlot>
    {
        public DisenchantInventorySlotWeightedRandom(SaveGame saveGame)
        {
            foreach (BaseInventorySlot inventorySlot in saveGame.SingletonRepository.InventorySlots)
            {
                if (inventorySlot.CanBeDisenchanted)
                {
                    Add(1, inventorySlot);
                }
            }
        }
    }
}
