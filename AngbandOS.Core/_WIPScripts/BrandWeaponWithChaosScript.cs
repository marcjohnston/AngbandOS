// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BrandWeaponWithChaosScript : Script, IScript, ICastSpellScript
{
    private BrandWeaponWithChaosScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Enchants the melee weapon with chaos.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Item? item = Game.GetInventoryItem(InventorySlotEnum.MeleeWeapon);

        // We must have a non-rare, non-artifact weapon that isn't cursed
        if (item != null)
        {
            if (!item.IsArtifact && !item.IsRare() && !item.EffectiveItemPropertySet.IsCursed)
            {
                string act;
                string itemName = item.GetDescription(false);

                // Make it a chaotic weapon
                act = "is engulfed in raw chaos!";
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponChaoticItemEnhancement)));

                // Let the player know what happened
                Game.MsgPrint($"Your {itemName} {act}");
                Game.Enchant(item, Game.RandomLessThan(3) + 4, Constants.EnchTohit | Constants.EnchTodam);
            }
        }
        else
        {
            Game.MsgPrint("The Branding failed.");
        }
    }
    public string LearnedDetails => "";
}
