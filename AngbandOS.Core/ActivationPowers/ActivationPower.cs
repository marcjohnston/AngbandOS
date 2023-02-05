namespace AngbandOS.Core.ActivationPowers
{
    [Serializable]
    /// <summary>
    /// Represents the base functionality for an ArtifactPower.  All ArtifactPower objects need to implement this functionality.
    /// </summary>
    internal abstract class ActivationPower
    {
        /// <summary>
        /// Returns the unique name for this activation power.
        /// </summary>
        public virtual string Name
        {
            get
            {
                return GetType().Name.Replace("ActivationPower", "");
            }
        }

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
        /// <param name="saveGame"></param>
        /// <returns></returns>
        public abstract bool Activate(SaveGame saveGame);

        /// <summary>
        /// Returns the gold value of the artifact power.
        /// </summary>
        public abstract int Value { get; }

        /// <summary>
        /// Returns the description of the artifact power.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Applies a special sustain to ItemCharacteristics.
        /// </summary>
        public abstract Action<IItemCharacteristics> ActivateSpecialSustain { get; }

        /// <summary>
        /// Applies a special power to ItemCharacteristics.
        /// </summary>
        public abstract Action<IItemCharacteristics> ActivateSpecialPower { get; }

        /// <summary>
        /// Applies a special ability to ItemCharacteristics.
        /// </summary>
        public abstract Action<IItemCharacteristics> ActivateSpecialAbility { get; }
    }
}
