// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BrandWeaponWithFireOrIceScript : Script, IScript
{
    private BrandWeaponWithFireOrIceScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Enchants the melee weapon with fire 25% of the time; ice, the other 75%.
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

            // Make it a fire or ice weapon
            if (SaveGame.Rng.RandomLessThan(100) < 25)
            {
                act = "is covered in a fiery shield!";
                item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfBurning;
            }
            else
            {
                act = "glows deep, icy blue!";
                item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfFreezing;
            }

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
