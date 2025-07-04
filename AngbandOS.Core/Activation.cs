﻿// AngbandOS: 2022 Marc Johnston
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
internal class Activation : IGetKey, IToJson
{
    protected readonly Game Game;
    public Activation(Game game, ActivationGameConfiguration activationGameConfiguration)
    {
        Game = game;
        Key = activationGameConfiguration.Key ?? activationGameConfiguration.GetType().Name;
        Name = activationGameConfiguration.Name;
        PreActivationMessage = activationGameConfiguration.PreActivationMessage;
        Value = activationGameConfiguration.Value;
        RechargeTimeRollExpression = activationGameConfiguration.RechargeTimeRollExpression;
        ActivationCancellableScriptItemBindingKey = activationGameConfiguration.ActivationCancellableScriptItemBindingKey;
    }

    /// <summary>
    /// Returns the unique name for this activation.  This name should be capitalized appropriately.
    /// </summary>
    public virtual string Name { get; }

    /// <summary>
    /// Returns the message to be displayed to the player, before the activation and before a direction is requested, or null, if no message is to be rendered.  Returns null, by default.  This message also supports string interpolation:
    /// {0} - will be replaced with the associated <see cref="ItemClass.Name"/>. 
    /// </summary>
    public virtual string? PreActivationMessage { get; } = null; // TODO: Need to accomodate proper grammar for items that use the {0} class name and a verb (e.g. your gauntlets glow vs your scale mail glows)

    /// <summary>
    /// Returns a Roll that determines the amount of time the activation needs to recharge.  This property is bound from the <see cref="RechargeTimeRollExpression"/> property during the bind phase.
    /// </summary>
    public Expression RechargeTimeRoll { get; protected set; }

    /// <summary>
    /// Returns the gold value of the activation.
    /// </summary>
    public virtual int Value { get; }

    /// <summary>
    /// Returns the description of the activation.
    /// </summary>
    public string Description => $"{Name.ToLower()} every {RechargeTimeRoll} turns";

    /// <summary>
    /// Performs the item activation by calling the <see cref="OnActivate"/> method that must be inherited by a derived class and return false, if the script is 
    /// cancelled; true, otherwise.  A script is considered to have been run if it fails by chance.  A script is considered cancelled
    /// if the player doesn't have an item for the script to run against, or the player cancels an item or other selection.
    /// </summary>
    /// <returns></returns>
    public UsedResultEnum Activate(Item item) // TODO: This should be an ActivatibleScript
    {
        if (PreActivationMessage != null)
        {
            string itemClassName = item.ItemClass.Name.ToLower();
            string formattedPreActivationMessage = String.Format(PreActivationMessage, itemClassName);
            Game.MsgPrint(formattedPreActivationMessage);
        }
        UsedResultEnum usedResult = ActivationCancellableScript.ExecuteActivateItemScript(item);
        if (usedResult == UsedResultEnum.True)
        {
            item.ActivationRechargeTimeRemaining = Game.ComputeIntegerExpression(RechargeTimeRoll).Value;
        }
        return usedResult;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        ActivationGameConfiguration gameConfiguration = new()
        {
            Key = Key,
            Name = Name,
            PreActivationMessage = PreActivationMessage,
            Value = Value,
            RechargeTimeRollExpression = RechargeTimeRollExpression,
            ActivationCancellableScriptItemBindingKey = ActivationCancellableScriptItemBindingKey,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }

    public virtual string Key { get; }

    public string GetKey => Key;

    public void Bind()
    {
        RechargeTimeRoll = Game.ParseNumericExpression(RechargeTimeRollExpression);
        ActivationCancellableScript = Game.SingletonRepository.Get<IActivateItemScript>(ActivationCancellableScriptItemBindingKey);
    }

    /// <summary>
    /// Returns a Roll expression that determines the amount of time the activation needs to recharge.  This property is used to bind the <see cref="RechargeTimeRoll ">/> property during the bind phase.
    /// </summary>
    protected virtual string RechargeTimeRollExpression { get; }

    /// <summary>
    /// Returns the binding key for the <see cref="IActivateItemScript"/> that should be run when the activation is executed.  This property is used to bind
    /// the <see cref="ActivationCancellableScript"/> property during the binding phase.
    /// </summary>
    protected virtual string ActivationCancellableScriptItemBindingKey { get; }

    /// <summary>
    /// Returns the binding key for the <see cref="IActivateItemScript"/> that should be run when the activation is executed.  This property is used to bind
    /// the <see cref="ActivationCancellableScript"/> property during the binding phase.
    /// </summary>
    public IActivateItemScript ActivationCancellableScript { get; protected set; }
}
