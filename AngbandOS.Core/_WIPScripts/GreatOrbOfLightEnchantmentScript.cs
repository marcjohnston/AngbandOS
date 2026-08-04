// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

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
            weightedRandomAction.Add(2, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(ResDarkAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(ResLightAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(ResBlindAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(ResFearAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(ResAcidAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(ResElecAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(ResFireAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(ResColdAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(ResPoisAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(ResConfAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(ResSoundAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(ResShardsAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(ResNetherAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(ResNexusAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(ResChaosAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(ResDisenAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.FreeAct = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.HoldLife = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(SustStrAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(SustIntAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(SustWisAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(SustDexAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(SustConAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(SustChaAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Feather = true);
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(SeeInvisAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(TelepathyAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(SlowDigestAttribute)).Set());
            weightedRandomAction.Add(1, () => item.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(RegenAttribute)).Set());
            weightedRandomAction.Choose();
        }
    }
}
