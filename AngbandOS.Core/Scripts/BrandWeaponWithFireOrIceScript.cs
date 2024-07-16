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
    private BrandWeaponWithFireOrIceScript(Game game) : base(game) { }

    /// <summary>
    /// Enchants the melee weapon with fire 25% of the time; ice, the other 75%.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Item? item = Game.GetInventoryItem(InventorySlot.MeleeWeapon);
        // We must have a non-rare, non-artifact weapon that isn't cursed
        if (item != null && !item.IsArtifact && !item.IsRare() && !item.IsCursed)
        {
            string act;
            string itemName = item.GetDescription(false);

            // Make it a fire or ice weapon
            if (Game.RandomLessThan(100) < 25)
            {
                act = "is covered in a fiery shield!";
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(WeaponOfBurningRareItem));
            }
            else
            {
                act = "glows deep, icy blue!";
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(WeaponOfFreezingRareItem));
            }

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
