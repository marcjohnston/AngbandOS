// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using static System.Reflection.Metadata.BlobBuilder;
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BrandBoltsScript : Script, IScript, ICastSpellScript, IActivateItemScript
{
    private BrandBoltsScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Runs the successful script and returns true, because the player cannot cancel the script.
    /// </summary>
    /// <returns></returns>
    public UsedResultEnum ExecuteActivateItemScript(Item item)
    {
        ExecuteScript();

        // Return true because the player cannot cancel the script.
        return UsedResultEnum.True;
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        for (int i = 0; i < InventorySlotEnum.PackCount; i++)
        {
            // Find a set of non-artifact bolts in our inventory
            Item? item = Game.GetInventoryItem(i);
            if (item == null || !Game.ItemMatchesFilter(item, Game.SingletonRepository.Get<ItemFilter>(nameof(BoltsOfValueItemFilter))))
            {
                continue;
            }
            if (item.IsArtifact || item.IsRare())
            {
                continue;
            }

            // Skip cursed or broken bolts
            RoItemPropertySet effectiveItemCharacteristics = item.GetEffectiveItemProperties();
            if (effectiveItemCharacteristics.IsCursed || item.IsBroken)
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
            item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(AmmoOfFlameItemEnhancement));
            Game.Enchant(item, Game.RandomLessThan(3) + 4, Constants.EnchTohit | Constants.EnchTodam);

            // Quit after the first bolts have been upgraded
            return;
        }

        // We fell off the end of the inventory without enchanting anything
        Game.MsgPrint("The fiery enchantment failed.");
    }
}
