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
            weightedRandomAction.Add(2, () => item.EffectiveAttributeSet.ResDark = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.ResLight = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.ResBlind = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.ResFear = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.ResAcid = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.ResElec = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.ResFire = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.ResCold = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.ResPois = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.ResConf = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.ResSound = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.ResShards = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.ResNether = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.ResNexus = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.ResChaos = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.ResDisen = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.FreeAct = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.HoldLife = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.SustStr = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.SustInt = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.SustWis = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.SustDex = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.SustCon = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.SustCha = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Feather = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.SeeInvis = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Telepathy = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.SlowDigest = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Regen = true);
            weightedRandomAction.Choose();
        }
    }
}
