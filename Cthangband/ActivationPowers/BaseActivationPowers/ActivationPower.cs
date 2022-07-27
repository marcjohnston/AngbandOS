namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Represents the base functionality for an ArtifactPower.  All ArtifactPower objects need to implement this functionality.
    /// </summary>
    internal abstract class ActivationPower : IActivationPower
    {
        /// <inheritdoc></inheritdoc>
        public virtual string Name
        {
            get
            {
                return GetType().Name.Replace("ActivationPower", "");
            }
        }

        /// <inheritdoc></inheritdoc>
        public abstract string PreActivationMessage { get; }

        /// <inheritdoc></inheritdoc>
        public abstract int RechargeTime(Player player);

        /// <inheritdoc></inheritdoc>
        public abstract int RandomChance { get; }

        /// <inheritdoc></inheritdoc>
        public abstract bool Activate(Player player, Level level);

        /// <inheritdoc></inheritdoc>
        public abstract int Value { get; }

        /// <inheritdoc></inheritdoc>
        public abstract string Description { get; }

        /// <inheritdoc></inheritdoc>
        public abstract uint SpecialSustainFlag { get; }

        /// <inheritdoc></inheritdoc>
        public abstract uint SpecialPowerFlag { get; }

        /// <inheritdoc></inheritdoc>
        public abstract uint SpecialAbilityFlag { get; }
    }
}
