// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(Title = "Item Identification", EntityNoun = "item identification")]
public class ItemIdentificationGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Attribute Filter Binding Key",
        Summary = "Specifies the binding key for the attribute filter used to identify the item.",
        DataType = "string")]
    public virtual string AttributeFilterBindingKey { get; set; }

    [ConfigurationMetadata(
        Title = "Interpolation Expression Attribute Names",
        Summary = "Specifies the attribute names whose values are available for interpolation in the effect description.",
        DataType = "string[]?")]
    public virtual string[]? InterpolationExpressionAttributeNames { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Effect Description",
        Summary = "Specifies the description of the effect produced when the item is identified.",
        DataType = "string")]
    public virtual string[] EffectDescription { get; set; }
}