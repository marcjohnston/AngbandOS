// AngbandOS: 2022 Marc Johnston
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
        item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfPowerItemEnhancement)));
        for (int i = 0; i < 3; i++)
        {
            WeightedRandomAction weightedRandomAction = new WeightedRandomAction(Game);
            weightedRandomAction.Add(2, () => item.EffectivePropertySet.ResDark = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.ResLight = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.ResBlind = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.ResFear = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.ResAcid = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.ResElec = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.ResFire = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.ResCold = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.ResPois = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.ResConf = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.ResSound = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.ResShards = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.ResNether = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.ResNexus = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.ResChaos = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.ResDisen = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.FreeAct = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.HoldLife = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SustStr = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SustInt = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SustWis = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SustDex = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SustCon = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SustCha = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.Feather = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SeeInvis = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.Telepathy = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SlowDigest = true);
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.Regen = true);
            weightedRandomAction.Choose();
        }
    }
}
