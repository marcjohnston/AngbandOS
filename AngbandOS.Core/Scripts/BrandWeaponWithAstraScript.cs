﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BrandWeaponWithAstraScript : Script, IScript
{
    private BrandWeaponWithAstraScript(Game game) : base(game) { }

    /// <summary>
    /// Enchants the melee weapon as planar.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Item? item = Game.GetInventoryItem(InventorySlot.MeleeWeapon);

        // We must have a non-rare, non-artifact weapon that isn't cursed
        if (item != null && !item.IsArtifact && !item.IsRare() && !item.IsCursed())
        {
            string act;
            string itemName = item.Description(false, 0);

            // Make it a planar weapon
            act = "seems very unstable now.";
            item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(WeaponPlanarWeaponRareItem));
            item.TypeSpecificValue = Game.DieRoll(2);

            // Let the player know what happened
            Game.MsgPrint($"Your {itemName} {act}");
            Game.Enchant(item, Game.RandomLessThan(3) + 4, Constants.EnchTohit | Constants.EnchTodam);
        }
        else
        {
            Game.MsgPrint("The Branding failed.");
        }
    }
}