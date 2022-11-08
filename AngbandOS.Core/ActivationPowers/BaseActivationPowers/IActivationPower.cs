using AngbandOS.Enumerations;

namespace AngbandOS.ActivationPowers
{
    internal interface IActivationPower
    {
        /// <summary>
        /// Returns the unique name for this activation power.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Returns the message to be displayed to the player, before the activation power occurs.  No message is display, if empty or null.
        /// </summary>
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
        /// <param name="saveGame"></param>
        /// <returns></returns>
        bool Activate(SaveGame saveGame);

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
