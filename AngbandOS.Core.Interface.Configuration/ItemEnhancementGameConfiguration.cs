// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interface.Configuration;

/// <summary>
/// Represents a set of item characteristics that can be merged with another other IItemCharacterstics.  These objects are used by <see cref="RareItem"/> objects and the random 
/// artifact creation process.
/// </summary>
[Serializable]
public class ItemEnhancementGameConfiguration
{
    public virtual string? Key { get; set; } = null;
    public virtual (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings { get; set; } = null;
    public virtual (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings { get; set; } = null;
    public virtual (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings { get; set; } = null;

    /// <summary>
    /// Returns the <see cref="ItemFactory"/> objects that this <see cref="ItemEnhancement"/> applies to; or null, if this <see cref="ItemEnhancement"/> can
    /// be applied to all <see cref="ItemFactory"/> objects.  This property is used to bind the <see cref="ApplicableItemFactories"/> property.
    /// </summary>
    public virtual string[]? ApplicableItemFactoryBindingKeys { get; set; } = null;

    public virtual string? AdditionalItemEnhancementWeightedRandomBindingKey { get; set; } = null;

    /// <summary>
    /// Returns the name of the rare item characteristics to append to the description of the original item, or null, to not modify the name.  Returns null, by default.
    /// </summary>
    public virtual string? FriendlyName { get; set; } = null;

    /// <summary>
    /// Returns then name of an <see cref="Activation "/>, if the item can be activated; or null, if the item cannot be activated.  Dragon scale mail, rings of ice, acid and flames, the planar weapon, fixed artifacts and
    /// random artifacts may have an <see cref="Activation"/>.  Returns null, by default.  This property is used to bind the <see cref="Activation"/> property during the bind phase.
    /// </summary>
    /// <inheritdoc />
    public virtual string? ActivationName { get; set; }
    public virtual string? ArtifactBiasWeightedRandomBindingKey { get; set; } = null;

    /// <summary>
    /// Returns the color that items of this type should be rendered with.  This color will be initially used to set the <see cref="FlavorColor"/> and item categories
    /// that have flavor may change the FlavorColor based on the flavor.
    /// </summary>
    public virtual ColorEnum? Color { get; set; } = null;
}
