using AngbandOS.ActivationPowers;

namespace AngbandOS.ArtifactBiases
{
    /// <summary>
    /// Represents the interface for the bias used when giving random powers to an artifact.
    /// </summary>
    internal interface IArtifactBias
    {
        /// <summary>
        /// Returns the chance that the object will have immunity resistance.  The chance relates to a 1-in-chance value.
        /// </summary>
        int ImmunityLuckOneInChance { get; }

        /// <summary>
        /// Apply bonuses to the item and returns true, if additional bonuses can be applied.  By default, no bonuses are applied and false is returned.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool ApplyBonuses(Item item);

        /// <summary>
        /// Apply resistances to the item and returns true, if additional resistances can applied.  By default, no resistances are applied and false is returned.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool ApplyRandomResistances(Item item);

        /// <summary>
        /// Apply powers to the item and returns true, if additional powers can applied.  By default, no powers are applied and false is returned.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool ApplyMiscPowers(Item item);

        /// <summary>
        /// Apply slaying to the item and returns true, if additional slaying can applied.  By default, no slaying is applied and false is returned.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool ApplySlaying(Item item);

        /// <summary>
        /// Returns an activation type to be applied for the item or null when there is no biased activation type.  By default, null is returned.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        ActivationPower GetActivationPowerType(Item item);

        /// <summary>
        /// Returns the chance that an activation power is assigned.  A value greater than 100 (e.g. 101) guarantees activation power will be assigned.
        /// </summary>
        int ActivationPowerChance { get; }
    }
}
