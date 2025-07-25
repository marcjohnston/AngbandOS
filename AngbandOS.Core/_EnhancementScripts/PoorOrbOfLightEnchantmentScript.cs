﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PoorOrbOfLightEnchantmentScript : Script, IEnhancementScript
{
    private PoorOrbOfLightEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        switch (Game.DieRoll(2)) // Cursed
        {
            case 1:
                {
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfIrritationItemEnhancement)));
                    item.IsBroken = true;
                    item.EnchantmentItemProperties.IsCursed = true;
                    break;
                }
            case 2:
                {
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfInstabilityItemEnhancement)));
                    item.IsBroken = true;
                    item.EnchantmentItemProperties.IsCursed = true;
                    break;
                }
        }
    }
}
