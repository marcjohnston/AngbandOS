// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntityAttribute(
    Title = "Attribute Filter",
    EntityNoun = "Attribute Filter")]
public class AttributeFilterGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Bitwise Or Attribute Filter Bindings",
        Summary = "The attribute bindings used to filter for attributes where any specified bitwise value matches.",
        DataType = "(string AttributeKey, bool DesiredValue)[]?")]
    [ConfigurationTupleItemAttribute(
        "AttributeKey",
        Title = "Attribute Key")]
    [ConfigurationTupleItemAttribute(
        "DesiredValue",
        Title = "Desired Value")]
    public virtual (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Boolean Attribute Filter Bindings",
        Summary = "The attribute bindings used to filter boolean attributes by their desired values.",
        DataType = "(string AttributeKey, bool?[] DesiredValue)[]?")]
    [ConfigurationTupleItemAttribute(
        "AttributeKey",
        Title = "Attribute Key")]
    [ConfigurationTupleItemAttribute(
        "DesiredValue",
        Title = "Desired Value")]
    public virtual (string AttributeKey, bool?[] DesiredValue)[]? BoolAttributeFilterBindings { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Summation Attribute Filter Bindings",
        Summary = "The attribute bindings used to filter summed numeric attributes within a specified range.",
        DataType = "(string AttributeKey, int? StartingValue, int? EndingValue)[]?")]
    [ConfigurationTupleItemAttribute(
        "AttributeKey",
        Title = "Attribute Key")]
    [ConfigurationTupleItemAttribute(
        "StartingValue",
        Title = "Starting Value")]
    [ConfigurationTupleItemAttribute(
        "EndingValue",
        Title = "Ending Value")]
    public virtual (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Activation Attribute Non-Null",
        Summary = "Determines whether the activation attribute must be non-null.",
        DataType = "bool?")]
    public virtual bool? ActivationAttributeNonNull { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Artifact Bias Attribute Non-Null",
        Summary = "Determines whether the artifact bias attribute must be non-null.",
        DataType = "bool?")]
    public virtual bool? ArtifactBiasAttributeNonNull { get; set; } = null;
}