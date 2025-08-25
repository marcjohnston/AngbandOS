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
            weightedRandomAction.Add(2, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.ResDark, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.ResLight, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.ResBlind, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.ResFear, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.ResAcid, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.ResElec, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.ResFire, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.ResCold, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.ResPois, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.ResConf, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.ResSound, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.ResShards, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.ResNether, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.ResNexus, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.ResChaos, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.ResDisen, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.FreeAct, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.HoldLife, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.SustStr, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.SustInt, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.SustWis, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.SustDex, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.SustCon, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.SustCha, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.Feather, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.SeeInvis, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.Telepathy, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.SlowDigest, true));
            weightedRandomAction.Add(1, () => item.EffectivePropertySet.SetBoolValue(AttributeEnum.Regen, true));
            weightedRandomAction.Choose();
        }
    }
}
