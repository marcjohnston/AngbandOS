using Cthangband.ActivationPowers;

namespace Cthangband.ArtifactBiases
{
    /// <summary>
    /// Represents the bias used when applying special abilities to an artifact.
    /// </summary>
    internal abstract class ArtifactBias : IArtifactBias
    {
        /// <inheritdoc/>
        public virtual int ImmunityLuck => 20;

        /// <inheritdoc/>
        public virtual bool ApplyBonuses(Item item)
        {
            return false;
        }

        /// <inheritdoc/>
        public virtual bool ApplyRandomResistances(Item item)
        {
            return false;
        }

        /// <inheritdoc/>
        public virtual bool ApplyMiscPowers(Item item)
        {
            return false;
        }

        /// <inheritdoc/>
        public virtual bool ApplySlaying(Item item)
        {
            return false;
        }

        /// <inheritdoc/>
        public virtual IActivationPower GetActivationPowerType(Item item)
        {
            return null;
        }

        /// <inheritdoc/>
        public virtual int ActivationPowerChance => 101;
    }
}
