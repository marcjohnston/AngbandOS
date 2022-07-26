namespace Cthangband.ActivationPowers
{
    internal interface IActivationPower
    {
        string PreActivationMessage { get; }

        /// <summary>
        /// Returns the amount of time the artifact needs to recharge, if the Activate method returns true.
        /// </summary>
        int RechargeTime(Player player);

        /// <summary>
        /// Returns the chance this ArtifactPower will be selected when being chosen randomly.  
        /// </summary>
        int RandomChance { get; }

        /// <summary>
        /// Activates the artifact power; returning true, if the activation was successful.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="level"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Activate(Player player, Level level, Item item);

        /// <summary>
        /// Returns the gold value of the artifact power.
        /// </summary>
        int Value { get; }

        /// <summary>
        /// Returns the description of the artifact power.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Returns the special sustain flag.
        /// </summary>
        uint SpecialSustainFlag { get; }

        /// <summary>
        /// Returns the special power flag.
        /// </summary>
        uint SpecialPowerFlag { get; }

        /// <summary>
        /// Returns the special ability flag.
        /// </summary>
        uint SpecialAbilityFlag { get; }
    }
}
