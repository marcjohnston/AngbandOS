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
            weightedRandomAction.Add(2, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.ResDark, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.ResLight, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.ResBlind, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.ResFear, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.ResAcid, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.ResElec, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.ResFire, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.ResCold, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.ResPois, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.ResConf, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.ResSound, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.ResShards, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.ResNether, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.ResNexus, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.ResChaos, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.ResDisen, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.FreeAct, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.HoldLife, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.SustStr, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.SustInt, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.SustWis, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.SustDex, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.SustCon, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.SustCha, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.Feather, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.SeeInvis, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.Telepathy, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.SlowDigest, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.Regen, true));
            weightedRandomAction.Choose();
        }
    }
}
