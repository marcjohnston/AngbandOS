﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GreatOrbOfLightEnchantmentScript : Script, IEnhancementScript
{
    private GreatOrbOfLightEnchantmentScript(Game game) : base(game) { }

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
        item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfPowerItemEnhancement));
        for (int i = 0; i < 3; i++)
        {
            WeightedRandomAction weightedRandomAction = new WeightedRandomAction(Game);
            weightedRandomAction.Add(2, () => item.EnchantmentItemProperties.ResDark = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.ResLight = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.ResBlind = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.ResFear = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.ResAcid = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.ResElec = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.ResFire = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.ResCold = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.ResPois = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.ResConf = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.ResSound = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.ResShards = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.ResNether = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.ResNexus = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.ResChaos = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.ResDisen = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.FreeAct = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.HoldLife = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.SustStr = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.SustInt = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.SustWis = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.SustDex = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.SustCon = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.SustCha = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.Feather = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.SeeInvis = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.Telepathy = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.SlowDigest = true);
            weightedRandomAction.Add(1, () => item.EnchantmentItemProperties.Regen = true);
            weightedRandomAction.Choose();
        }
    }
}
