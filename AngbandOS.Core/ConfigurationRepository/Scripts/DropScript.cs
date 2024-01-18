// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DropScript : Script
{
    private DropScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        int amount = 1;
        // Get an item from the inventory/equipment
        if (!SaveGame.SelectItem(out Item? item, "Drop which item? ", true, true, false, null))
        {
            SaveGame.MsgPrint("You have nothing to drop.");
            return false;
        }
        if (item == null)
        {
            return false;
        }
        // Can't drop a cursed item
        if (item.IsInEquipment && item.IsCursed())
        {
            SaveGame.MsgPrint("Hmmm, it seems to be cursed.");
            return false;
        }
        // It's a stack, so find out how many to drop
        if (item.Count > 1)
        {
            amount = SaveGame.GetQuantity(null, item.Count, true);
            if (amount <= 0)
            {
                return false;
            }
        }
        // Dropping things takes half a turn
        SaveGame.EnergyUse = 50;
        // Drop it
        SaveGame.InvenDrop(item, amount);
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawEquippyFlaggedAction)).Set();
        return false;
    }
}
