namespace AngbandOS.Core.WeightedRandoms
{
    /// <summary>
    /// Represents a weighted random for inventory slots that represent armour.  Body, head, feet, arms, hands and cloak are
    /// armour inventory slots.
    /// </summary>
    internal class ArmourInventorySlotWeightedRandom : WeightedRandom<BaseInventorySlot>
    {
        public ArmourInventorySlotWeightedRandom(SaveGame saveGame)
        {
            foreach (BaseInventorySlot inventorySlot in saveGame.SingletonRepository.InventorySlots)
            {
                if (inventorySlot.IsArmour)
                {
                    Add(1, inventorySlot);
                }
            }
        }
    }
}
