// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
/// <summary>
/// Provides base functionality for an ArtifactPower that needs a direction/aiming.  This object inherits the base ArtifactPower but addings a GetDirectionWithAim
/// to the activation functionality.
/// </summary>
internal abstract class DirectionalActivation : BaseActivation, IGetKey
{
    protected DirectionalActivation(Game game) : base(game) { }

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

    /// <summary>
    /// Returns the message to be displayed to the player, after the player has selected a direction.  No message is rendered, if empty or null.  Returns null, by default.
    /// </summary>
    protected virtual string? PostAimingMessage => null;

    public virtual void Bind()
    {
        RechargeTimeRoll = Game.ParseRollExpression(RechargeTimeRollExpression);
        DirectionalActivationCancellableScript = Game.SingletonRepository.Get<IDirectionalActivationScript>(DirectionalActivationCancellableScriptBindingKey);
    }

    /// <summary>
    /// Returns a Roll expression that determines the amount of time the activation needs to recharge.  This property is used to bind the <see cref="RechargeTimeRoll ">/> property during the bind phase.
    /// </summary>
    protected abstract string RechargeTimeRollExpression { get; }

    /// <summary>
    /// Returns the binding key for the <see cref="IUsedScript"/> that should be run when the activation is executed.  This property is used to bind
    /// the <see cref="ActivationCancellableScript"/> property during the binding phase.
    /// </summary>
    protected abstract string DirectionalActivationCancellableScriptBindingKey { get; }

    /// <summary>
    /// Returns the binding key for the <see cref="IUsedScript"/> that should be run when the activation is executed.  This property is used to bind
    /// the <see cref="ActivationCancellableScript"/> property during the binding phase.
    /// </summary>
    public IDirectionalActivationScript DirectionalActivationCancellableScript { get; protected set; }

    protected override bool OnActivate(Item item)
    {
        if (!Game.GetDirectionWithAim(out int direction))
        {
            return false;
        }
        if (!String.IsNullOrEmpty(PostAimingMessage))
        {
            Game.MsgPrint(PostAimingMessage);
        }

        return DirectionalActivationCancellableScript.ExecuteDirectionalActivationScript(item, direction);
    }
}
