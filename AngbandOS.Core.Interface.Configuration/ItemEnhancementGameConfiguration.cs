// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

/// <summary>
/// Represents a set of item characteristics that can be merged with another other IItemCharacterstics.  These objects are used by <see cref="RareItem"/> objects and the random 
/// artifact creation process.
/// </summary>
[ConfigurationEntity(Title = "Item Enhancement", EntityNoun = "item enhancement")]
public class ItemEnhancementGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Summation Attribute and Expression Bindings",
        Summary = "The attribute names and expressions used to calculate summation-based item enhancements.",
        DataType = "(string AttributeName, string Expression)[]?")]
    [ConfigurationTupleItem("AttributeName", Title = "Attribute Name")]
    [ConfigurationTupleItem("Expression", Title = "Expression")]
    public virtual (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Bitwise OR Attribute and Expression Bindings",
        Summary = "The attribute names and Boolean expressions used to calculate bitwise-OR item enhancements.",
        DataType = "(string AttributeName, string BooleanExpression)[]?")]
    [ConfigurationTupleItem("AttributeName", Title = "Attribute Name")]
    [ConfigurationTupleItem("BooleanExpression", Title = "Boolean Expression")]
    public virtual (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Scripts Attribute and Script Bindings",
        Summary = "The attribute names and script names used to apply scripts as item enhancements.",
        DataType = "(string AttributeName, string[] ScriptNames)[]?")]
    [ConfigurationTupleItem("AttributeName", Title = "Attribute Name")]
    [ConfigurationTupleItem("ScriptNames", Title = "Script Names")]
    public virtual (string AttributeName, string[] ScriptNames)[]? ScriptsAttributeAndScriptBindings { get; set; } = null;

    /// <summary>
    /// Returns the <see cref="ItemFactory"/> objects that this <see cref="ItemEnhancement"/> applies to; or null, if this <see cref="ItemEnhancement"/> can
    /// be applied to all <see cref="ItemFactory"/> objects.  This property is used to bind the <see cref="ApplicableItemFactories"/> property.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Applicable Item Factory Binding Keys",
        Summary = "The binding keys of the item factories to which this item enhancement applies, or null when it can be applied to all item factories.",
        DataType = "string[]?")]
    public virtual string[]? ApplicableItemFactoryBindingKeys { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Additional Item Enhancement Weighted Random Binding Key",
        Summary = "The binding key of the weighted random configuration used to select an additional item enhancement.",
        DataType = "string?")]
    public virtual string? AdditionalItemEnhancementWeightedRandomBindingKey { get; set; } = null;

    /// <summary>
    /// Returns the name of the rare item characteristics to append to the description of the original item, or null, to not modify the name.  Returns null, by default.
    /// </summary>
    [ConfigurationMetadata(
        Title = "Friendly Name",
        Summary = "The name of the rare item characteristics to append to the description of the original item, or null to leave the original name unchanged.",
        DataType = "string?")]
    public virtual string? FriendlyName { get; set; } = null;

    /// <summary>
    /// Returns then name of an <see cref="Activation "/>, if the item can be activated; or null, if the item cannot be activated.  Dragon scale mail, rings of ice, acid and flames, the planar weapon, fixed artifacts and
    /// random artifacts may have an <see cref="Activation"/>.  Returns null, by default.  This property is used to bind the <see cref="Activation"/> property during the bind phase.
    /// </summary>
    /// <inheritdoc />
    [ConfigurationMetadata(
        Title = "Activation Name",
        Summary = "The name of the activation applied to the item, or null when the item cannot be activated.",
        DataType = "string?")]
    public virtual string? ActivationName { get; set; }

    [ConfigurationMetadata(
        Title = "Artifact Bias Weighted Random Binding Key",
        Summary = "The binding key of the weighted random configuration used to select an artifact bias.",
        DataType = "string?")]
    public virtual string? ArtifactBiasWeightedRandomBindingKey { get; set; } = null;
}