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
        item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(OrbOfPowerItemEnhancement));
        for (int i = 0; i < 3; i++)
        {
            WeightedRandomAction weightedRandomAction = new WeightedRandomAction(Game);
            weightedRandomAction.Add(2, () => item.Characteristics.ResDark = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResLight = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResBlind = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResFear = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResAcid = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResElec = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResFire = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResCold = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResPois = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResConf = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResSound = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResShards = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResNether = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResNexus = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResChaos = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResDisen = true);
            weightedRandomAction.Add(1, () => item.Characteristics.FreeAct = true);
            weightedRandomAction.Add(1, () => item.Characteristics.HoldLife = true);
            weightedRandomAction.Add(1, () => item.Characteristics.SustStr = true);
            weightedRandomAction.Add(1, () => item.Characteristics.SustInt = true);
            weightedRandomAction.Add(1, () => item.Characteristics.SustWis = true);
            weightedRandomAction.Add(1, () => item.Characteristics.SustDex = true);
            weightedRandomAction.Add(1, () => item.Characteristics.SustCon = true);
            weightedRandomAction.Add(1, () => item.Characteristics.SustCha = true);
            weightedRandomAction.Add(1, () => item.Characteristics.Feather = true);
            weightedRandomAction.Add(1, () => item.Characteristics.SeeInvis = true);
            weightedRandomAction.Add(1, () => item.Characteristics.Telepathy = true);
            weightedRandomAction.Add(1, () => item.Characteristics.SlowDigest = true);
            weightedRandomAction.Add(1, () => item.Characteristics.Regen = true);
            weightedRandomAction.Choose();
        }
    }
}
