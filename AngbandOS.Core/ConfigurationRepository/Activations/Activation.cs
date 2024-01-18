// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

[Serializable]
/// <summary>
/// Represents a power that can be assigned to a random artifact that can be activated.
/// </summary>
internal abstract class Activation : IGetKey<string>
{
    protected readonly SaveGame SaveGame;
    protected Activation(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public virtual string Key => GetType().Name;

    
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
    /// Returns the message to be displayed to the player, before the activation power occurs.  No message is display, if empty or null.  Returns null, by default.
    /// </summary>
    public virtual string? PreActivationMessage => null;

    /// <summary>
    /// Returns the amount of time the artifact needs to recharge, if the Activate method returns true.
    /// </summary>
    public abstract int RechargeTime();

    /// <summary>
    /// Returns the chance this ArtifactPower will be selected when being chosen randomly.  
    /// </summary>
    public abstract int RandomChance { get; }

    /// <summary>
    /// Activates the artifact power; returning true, if the activation was successful.
    /// </summary>
    /// <param name="saveGame"></param>
    /// <returns></returns>
    public abstract bool Activate();

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

    public string GetKey => Key;
}
