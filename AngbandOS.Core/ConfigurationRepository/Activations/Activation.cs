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

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind() { }

    /// <summary>
    /// Returns the unique name for this activation power.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Returns the message to be displayed to the player, before the activation power occurs.  No message is display, if empty or null.  Returns null, by default.
    /// This message is also displayed before a direction is requested from the player.
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
    protected abstract bool OnActivate(Item item);

    public bool Activate(Item item)
    {
        string itemName = item.Description(false, 0);
        if (!String.IsNullOrEmpty(PreActivationMessage))
        {
            SaveGame.MsgPrint(PreActivationMessage);
        }
        if (OnActivate(item))
        {
            item.RechargeTimeLeft = RechargeTime();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Returns the gold value of the artifact power.
    /// </summary>
    public abstract int Value { get; }

    /// <summary>
    /// Returns the description of the artifact power.
    /// </summary>
    public abstract string Description { get; }
}
