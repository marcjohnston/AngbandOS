﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal abstract class BaseActivation
{
    protected readonly Game Game;
    protected BaseActivation(Game game)
    {
        Game = game;
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
    /// Returns a Roll that determines the amount of time the activation needs to recharge.  This property is bound from the <see cref="RechargeTimeRollExpression"/> property during the bind phase.
    /// </summary>
    public Roll RechargeTimeRoll { get; protected set; }

    /// <summary>
    /// Returns the gold value of the activation.
    /// </summary>
    public abstract int Value { get; }

    /// <summary>
    /// Returns the description of the activation.
    /// </summary>
    public string Description => $"{Name.ToLower()} every {RechargeTimeRoll.Expression} turns";

    /// <summary>
    /// Performs the item activation.  Must be overridden by a derived class.  Returns false, if the activation is cancelled.  See <see cref="Activate"/> for more
    /// details.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    protected abstract bool OnActivate(Item item);

    /// <summary>
    /// Performs the item activation by calling the <see cref="OnActivate"/> method that must be inherited by a derived class and return false, if the script is 
    /// cancelled; true, otherwise.  A script is considered to have been run if it fails by chance.  A script is considered cancelled
    /// if the player doesn't have an item for the script to run against, or the player cancels an item or other selection.
    /// </summary>
    /// <returns></returns>
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
}