// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

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

    public virtual void Bind()
    {
        RechargeTimeRoll = Game.ParseRollExpression(RechargeTimeRollExpression);
    }

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
    /// Returns a Roll expression that determines the amount of time the activation needs to recharge.  This property is used to bind the <see cref="RechargeTimeRoll ">/> property during the bind phase.
    /// </summary>
    protected abstract string RechargeTimeRollExpression { get; }

    /// <summary>
    /// Returns a Roll that determines the amount of time the activation needs to recharge.  This property is bound from the <see cref="RechargeTimeRollExpression"/> property during the bind phase.
    /// </summary>
    public Roll RechargeTimeRoll { get; private set; }

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
            string itemClassName = item.ItemClass.Name.ToLower();
            string formattedPreActivationMessage = String.Format(PreActivationMessage, itemClassName);
            Game.MsgPrint(formattedPreActivationMessage);
        }
        if (OnActivate(item))
        {
            item.ActivationRechargeTimeRemaining = RechargeTimeRoll.Get(Game.UseRandom);
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
    public string Description => $"{Name.ToLower()} every {RechargeTimeRoll.Expression} turns";
}
