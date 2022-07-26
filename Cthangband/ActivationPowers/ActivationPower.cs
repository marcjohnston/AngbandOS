namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Represents the base functionality for an ArtifactPower.  All ArtifactPower objects need to implement this functionality.
    /// </summary>
    internal abstract class ActivationPower : IActivationPower
    {
        /// <summary>
        /// Returns the message to be displayed to the player, before the activation power occurs.  No message is display, if empty or null.
        /// </summary>
        public abstract string PreActivationMessage { get; }

        /// <summary>
        /// Returns the amount of time the artifact needs to recharge, if the Activate method returns true.
        /// </summary>
        public abstract int RechargeTime(Player player);

        /// <summary>
        /// Returns the chance this ArtifactPower will be selected when being chosen randomly.  
        /// </summary>
        public abstract int RandomChance { get; }

        /// <summary>
        /// Activates the artifact power; returning true, if the activation was successful.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="level"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public abstract bool Activate(Player player, Level level, Item item);

        /// <summary>
        /// Returns the gold value of the artifact power.
        /// </summary>
        public abstract int Value { get; }

        /// <summary>
        /// Returns the description of the artifact power.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Returns the special sustain flag.
        /// </summary>
        public abstract uint SpecialSustainFlag { get; }

        /// <summary>
        /// Returns the special power flag.
        /// </summary>
        public abstract uint SpecialPowerFlag { get; }

        /// <summary>
        /// Returns the special ability flag.
        /// </summary>
        public abstract uint SpecialAbilityFlag { get; }
    }
}
