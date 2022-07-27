namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Represents the base functionality for an ArtifactPower.  All ArtifactPower objects need to implement this functionality.
    /// </summary>
    internal abstract class ActivationPower : IActivationPower
    {
        /// <inheritdoc/>
        public virtual string Name
        {
            get
            {
                return GetType().Name.Replace("ActivationPower", "");
            }
        }

        /// <inheritdoc/>
        public abstract string PreActivationMessage { get; }

        /// <inheritdoc/>
        public abstract int RechargeTime(Player player);

        /// <inheritdoc/>
        public abstract int RandomChance { get; }

        /// <inheritdoc/>
        public abstract bool Activate(Player player, Level level);

        /// <inheritdoc/>
        public abstract int Value { get; }

        /// <inheritdoc/>
        public abstract string Description { get; }

        /// <inheritdoc/>
        public abstract uint SpecialSustainFlag { get; }

        /// <inheritdoc/>
        public abstract uint SpecialPowerFlag { get; }

        /// <inheritdoc/>
        public abstract uint SpecialAbilityFlag { get; }
    }
}
