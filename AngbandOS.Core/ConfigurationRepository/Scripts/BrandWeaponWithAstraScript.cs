// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BrandWeaponWithAstraScript : Script, IScript
{
    private BrandWeaponWithAstraScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Enchants the melee weapon as planar.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Item? item = SaveGame.GetInventoryItem(InventorySlot.MeleeWeapon);

        // We must have a non-rare, non-artifact weapon that isn't cursed
        if (item != null && item.FixedArtifact == null && !item.IsRare() && string.IsNullOrEmpty(item.RandartName) && !item.IsCursed())
        {
            string act;
            string itemName = item.Description(false, 0);

            // Make it a planar weapon
            act = "seems very unstable now.";
            item.RareItemTypeIndex = RareItemTypeEnum.WeaponPlanarWeapon;
            item.TypeSpecificValue = SaveGame.Rng.DieRoll(2);

            // Let the player know what happened
            SaveGame.MsgPrint($"Your {itemName} {act}");
            SaveGame.Enchant(item, SaveGame.Rng.RandomLessThan(3) + 4, Constants.EnchTohit | Constants.EnchTodam);
        }
        else
        {
            SaveGame.MsgPrint("The Branding failed.");
        }
    }
}
