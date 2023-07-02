// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.WeightedRandoms;

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
