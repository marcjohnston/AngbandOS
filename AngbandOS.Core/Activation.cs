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
internal abstract class Activation : BaseActivation, IGetKey
{
    protected Activation(Game game) : base(game) { }

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
        ActivationCancellableScript = Game.SingletonRepository.Get<IUsedScriptItem>(ActivationCancellableScriptItemBindingKey);
    }

    /// <summary>
    /// Returns a Roll expression that determines the amount of time the activation needs to recharge.  This property is used to bind the <see cref="RechargeTimeRoll ">/> property during the bind phase.
    /// </summary>
    protected abstract string RechargeTimeRollExpression { get; }

    /// <summary>
    /// Returns the binding key for the <see cref="ICancellableScript"/> that should be run when the activation is executed.  This property is used to bind
    /// the <see cref="ActivationCancellableScript"/> property during the binding phase.
    /// </summary>
    protected abstract string ActivationCancellableScriptItemBindingKey { get; }

    /// <summary>
    /// Returns the binding key for the <see cref="ICancellableScript"/> that should be run when the activation is executed.  This property is used to bind
    /// the <see cref="ActivationCancellableScript"/> property during the binding phase.
    /// </summary>
    public IUsedScriptItem ActivationCancellableScript { get; protected set; }

    /// <summary>
    /// Performs the item activation and return false, if the script is cancelled; true, otherwise.  A script is considered to have been run if it fails by chance.  A script is considered cancelled
    /// if the player doesn't have an item for the script to run against, or the player cancels an item or other selection.
    /// </summary>
    /// <returns></returns>
    /// <param name="item">The item that was activated.</param>
    protected override bool OnActivate(Item item)
    {
        return ActivationCancellableScript.ExecuteUsedScriptItem(item);
    }
}
