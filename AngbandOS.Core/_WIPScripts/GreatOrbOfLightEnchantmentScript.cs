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
            weightedRandomAction.Add(2, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ResDarkAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ResLightAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ResBlindAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ResFearAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ResAcidAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ResElecAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ResFireAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ResColdAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ResPoisAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ResConfAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ResSoundAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ResShardsAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ResNetherAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ResNexusAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ResChaosAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ResDisenAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.FreeAct = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.HoldLife = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(SustStrAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(SustIntAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(SustWisAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(SustDexAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(SustConAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(SustChaAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Feather = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(SeeInvisAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(TelepathyAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(SlowDigestAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BoolSetEffectiveAttributeValue>(nameof(RegenAttribute)).Set());
            weightedRandomAction.Choose();
        }
    }
}
