// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class AttributeFilterGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("(string AttributeKey, bool DesiredValue)[]?",
        Title = "Bitwise Or Attribute Filter Bindings",
        Description = "The attribute bindings used to filter for attributes where any specified bitwise value matches.")]
    [ConfigurationTupleItem(
        "AttributeKey",
        Title = "Attribute Key")]
    [ConfigurationTupleItem(
        "DesiredValue",
        Title = "Desired Value")]
    public virtual (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings { get; set; } = null;

    [ConfigurationProperty("(string AttributeKey, bool?[] DesiredValue)[]?",
        Title = "Boolean Attribute Filter Bindings",
        Description = "The attribute bindings used to filter boolean attributes by their desired values.")]
    [ConfigurationTupleItem(
        "AttributeKey",
        Title = "Attribute Key")]
    [ConfigurationTupleItem(
        "DesiredValue",
        Title = "Desired Value")]
    public virtual (string AttributeKey, bool?[] DesiredValue)[]? BoolAttributeFilterBindings { get; set; } = null;

    [ConfigurationProperty("(string AttributeKey, int? StartingValue, int? EndingValue)[]?",
        Title = "Summation Attribute Filter Bindings",
        Description = "The attribute bindings used to filter summed numeric attributes within a specified range.")]
    [ConfigurationTupleItem(
        "AttributeKey",
        Title = "Attribute Key")]
    [ConfigurationTupleItem(
        "StartingValue",
        Title = "Starting Value")]
    [ConfigurationTupleItem(
        "EndingValue",
        Title = "Ending Value")]
    public virtual (string AttributeKey, int? StartingValue, int? EndingValue)[]? SummationAttributeFilterBindings { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Activation Attribute Non-Null",
        Description = "Determines whether the activation attribute must be non-null.")]
    public virtual bool? ActivationAttributeNonNull { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Artifact Bias Attribute Non-Null",
        Description = "Determines whether the artifact bias attribute must be non-null.")]
    public virtual bool? ArtifactBiasAttributeNonNull { get; set; } = null;
}