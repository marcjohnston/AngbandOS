// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using static System.Reflection.Metadata.BlobBuilder;

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BrandBoltsScript : Script, IScript, ISuccessfulScript
{
    private BrandBoltsScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Attempts to five a fire brand the first set of bolts found in the players inventory.  Returns true, if bolts were enchanted; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessfulScript()
    {
        for (int i = 0; i < InventorySlot.PackCount; i++)
        {
            // Find a set of non-artifact bolts in our inventory
            Item? item = SaveGame.GetInventoryItem(i);
            if (item == null || item.Category != ItemTypeEnum.Bolt)
            {
                continue;
            }
            if (item.IsArtifact || item.IsRare())
            {
                continue;
            }

            // Skip cursed or broken bolts
            if (item.IsCursed() || item.IsBroken())
            {
                continue;
            }

            // Only a 25% chance of success per set of bolts
            if (SaveGame.RandomLessThan(100) < 75)
            {
                continue;
            }

            // Make the bolts into bolts of flame
            SaveGame.MsgPrint("Your bolts are covered in a fiery aura!");
            item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(AmmoOfFlameRareItem));
            SaveGame.Enchant(item, SaveGame.RandomLessThan(3) + 4, Constants.EnchTohit | Constants.EnchTodam);

            // Quit after the first bolts have been upgraded
            return true;
        }

        // We fell off the end of the inventory without enchanting anything
        SaveGame.MsgPrint("The fiery enchantment failed.");
        return false;
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessfulScript();
    }
}
