// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

[Serializable]
/// <summary>
/// Represents a power that can be assigned to a random artifact that can be activated.  Fixed artifacts are now using this Activation.
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

    public virtual void Bind() { }

    /// <summary>
    /// Returns the unique name for this activation.  This name should be capitalized appropriately.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Returns the message to be displayed to the player, before the activation and before a direction is requested, or null, if no message is to be rendered.  Returns null, by default.  This message also supports string interpolation:
    /// {0} - will be replaced with the associated <see cref="ItemClass.Name"/>. 
    /// </summary>
    public virtual string? PreActivationMessage => null; // TODO: Need to accomodate proper grammar for items that use the {0} class name and a verb (e.g. your gauntlets glow vs your scale mail glows)

    /// <summary>
    /// Returns the amount of time the artifact needs to recharge, if the Activate method returns true.
    /// </summary>
    public abstract int RechargeTime(); // TODO: This needs to be converted into Roll that has a description.

    /// <summary>
    /// Activates the artifact power; returning false, if the activation was cancelled by the user; true, otherwise.
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    protected abstract bool OnActivate(Item item);

    public bool Activate(Item item) // TODO: This should be an ActivatibleScript
    {
        if (PreActivationMessage != null)
        {
            string itemClassName = item.Factory.ItemClass.Name.ToLower();
            string formattedPreActivationMessage = String.Format(PreActivationMessage, itemClassName);
            Game.MsgPrint(formattedPreActivationMessage);
        }
        if (OnActivate(item))
        {
            item.ActivationRechargeTimeRemaining = RechargeTime();
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
