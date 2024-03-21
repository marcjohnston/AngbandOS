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
internal abstract class Activation : IGetKey
{
    protected readonly Game Game;
    protected Activation(Game game)
    {
        Game = game;
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
    /// Returns the chance the activation will be selected when being chosen randomly.  
    /// </summary>
    public abstract int RandomChance { get; }

    /// <summary>
    /// Activates the artifact power; returning false, if the activation was cancelled by the user; true, otherwise.
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    protected abstract bool OnActivate(Item item);

    public bool Activate(Item item)
    {
        if (PreActivationMessage != null)
        {
            string itemClassName = item.Factory.ItemClass.Name.ToLower();
            string formattedPreActivationMessage = String.Format(PreActivationMessage, itemClassName);
            Game.MsgPrint(formattedPreActivationMessage);
        }
        if (OnActivate(item))
        {
            item.RechargeTimeLeft = RechargeTime();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Returns the gold value of the activation.
    /// </summary>
    public abstract int Value { get; }

    /// <summary>
    /// Returns the description of the activation.
    /// </summary>
    public string Description => $"{Name.ToLower()} every {Frequency} turns";

    public abstract string Frequency { get; }
}
