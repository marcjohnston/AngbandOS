// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BrandWeaponAsVampiricScript : Script, IScript, ICastSpellScript
{
    private BrandWeaponAsVampiricScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Enchants the first melee weapon as vampiric.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        WieldSlot meleeWeaponWieldSlot = Game.SingletonRepository.Get<WieldSlot>().Single(_wieldSlot => _wieldSlot.IsMeleeWeapon);
        foreach (int inventorySlot in meleeWeaponWieldSlot.InventorySlots)
        {
            Item? item = Game.GetInventoryItem(inventorySlot);

            // We must have a non-rare, non-artifact weapon that isn't cursed
            if (item is not null && !item.IsArtifact && !item.IsRare && !item.EffectiveAttributeSet.IsCursed)
            {
                string itemName = item.GetDescription(false);

                // Make it a vampiric weapon
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponVampiricItemEnhancement)));

                // Let the player know what happened
                Game.MsgPrint($"Your {itemName} thirsts for blood!");
                Game.Enchant(item, Game.RandomLessThan(3) + 4, Constants.EnchTohit | Constants.EnchTodam);
                return;
            }
        }
        Game.MsgPrint("The Branding failed.");
    }
    public string LearnedDetails => "";
}
