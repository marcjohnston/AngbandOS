// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using static System.Reflection.Metadata.BlobBuilder;

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BrandBoltsScript : Script, IScript, ISuccessByChanceScript, ICancellableScript
{
    private BrandBoltsScript(Game game) : base(game) { }

    /// <summary>
    /// Runs the successful script and returns true, because the player cannot cancel the script.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteCancellableScript()
    {
        ExecuteSuccessByChanceScript();

        // Return true because the player cannot cancel the script.
        return true;
    }

    /// <summary>
    /// Attempts to aaply a fire brand to the first set of bolts found in the players inventory.  Returns true, if bolts were enchanted; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessByChanceScript()
    {
        for (int i = 0; i < InventorySlot.PackCount; i++)
        {
            // Find a set of non-artifact bolts in our inventory
            Item? item = Game.GetInventoryItem(i);
            if (item == null || item.Category != ItemTypeEnum.Bolt)
            {
                continue;
            }
            if (item.IsArtifact || item.IsRare())
            {
                continue;
            }

            // Skip cursed or broken bolts
            if (item.IsCursed || item.IsBroken)
            {
                continue;
            }

            // Only a 25% chance of success per set of bolts
            if (Game.RandomLessThan(100) < 75)
            {
                continue;
            }

            // Make the bolts into bolts of flame
            Game.MsgPrint("Your bolts are covered in a fiery aura!");
            item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(AmmoOfFlameRareItem));
            Game.Enchant(item, Game.RandomLessThan(3) + 4, Constants.EnchTohit | Constants.EnchTodam);

            // Quit after the first bolts have been upgraded
            return true;
        }

        // We fell off the end of the inventory without enchanting anything
        Game.MsgPrint("The fiery enchantment failed.");
        return false;
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessByChanceScript();
    }
}
