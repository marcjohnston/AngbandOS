// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents the bias used when applying special abilities to an artifact.
/// </summary>
[Serializable]
internal abstract class ArtifactBias : IGetKey
{
    protected readonly Game Game;
    public string GetKey => Key;

    protected ArtifactBias(Game game)
    {
        Game = game;
    }

    public abstract string AffinityName { get; }
    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public void Bind()
    {
        if (RandomResistanceTuples != null)
        {
            List<(ItemTest, ProbabilityExpression, ItemEnhancement, ProbabilityExpression)> randomResistances = new List<(ItemTest, ProbabilityExpression, ItemEnhancement, ProbabilityExpression)>();
            foreach ((string itemTestName, string itemTestProbabilityExpression, string itemAdditiveBundleName, string moreProbabilityExpression) in RandomResistanceTuples)
            {
                ItemTest itemTest = Game.SingletonRepository.Get<ItemTest>(itemTestName);
                ProbabilityExpression itemTestProbability = Game.ParseProbabilityExpression(itemTestProbabilityExpression);
                ItemEnhancement itemAdditiveBundle = Game.SingletonRepository.Get<ItemEnhancement>(itemAdditiveBundleName);
                ProbabilityExpression moreProbability = Game.ParseProbabilityExpression(moreProbabilityExpression);
                randomResistances.Add((itemTest, itemTestProbability, itemAdditiveBundle, moreProbability));
            }
            RandomResistances = randomResistances.ToArray();
        }
    }

    /// <summary>
    /// Returns the chance that the object will have immunity resistance.  The chance relates to a 1-in-chance value.
    /// </summary>
    public virtual int ImmunityLuckOneInChance => 20;

    /// <summary>
    /// Apply bonuses to the item and returns true, if additional bonuses can be applied.  By default, no bonuses are applied and false is returned.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual bool ApplyRandomArtifactBonuses(RwItemPropertySet characteristics) => false;

    protected virtual (string ItemCharacteristicTestName, string ItemAdditiveBundleProbabilityExpression, string ItemAdditiveBundleName, string MoreProbabilityExpression)[]? RandomResistanceTuples => null;
    public (ItemTest, ProbabilityExpression, ItemEnhancement, ProbabilityExpression)[]? RandomResistances { get; private set; } = null;
            
    /// <summary>
    /// Apply resistances to the item and returns true, if additional resistances can be applied.  By default, no resistances are applied and false is returned.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool ApplyRandomResistances(RwItemPropertySet characteristics)
    {
        if (RandomResistances != null)
        {
            foreach ((ItemTest itemTest, ProbabilityExpression itemTestProbability, ItemEnhancement itemEnhancement, ProbabilityExpression moreProbability) in RandomResistances)
            {
                // Test the probability and if whether the item test pass.
                if (itemTestProbability.Test() && itemTest.Test(characteristics))
                {
                    characteristics = characteristics.Merge(itemEnhancement.GenerateItemCharacteristics());
                    if (moreProbability.Test())
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Apply powers to the item and returns true, if additional powers can applied.  By default, no powers are applied and false is returned.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual bool ApplyMiscPowers(RwItemPropertySet characteristics) => false;

    /// <summary>
    /// Apply slaying to the item and returns true, if additional slaying can applied.  By default, no slaying is applied and false is returned.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual bool ApplySlaying(RwItemPropertySet characteristics) => false;

    /// <summary>
    /// Returns an activation type to be applied for the item or null when there is no biased activation type.  By default, null is returned.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual Activation? GetActivationPowerType() => null;

    /// <summary>
    /// Returns the chance that an activation power is assigned.  A value greater than 100 (e.g. 101) guarantees activation power will be assigned.
    /// </summary>
    public virtual int ActivationPowerChance => 101;
}
