
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntityAttribute(
    Title = "Animation",
    EntityNoun = "Animation")]
public class AnimationGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Character",
        Summary = "The character displayed by the animation.",
        DataType = "char")]
    public virtual char Character { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Color",
        Summary = "The primary color used by the animation.",
        DataType = "ColorEnum")]
    public virtual ColorEnum Color { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Name",
        Summary = "The name of the animation.",
        DataType = "string")]
    public virtual string Name { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Alternate Color",
        Summary = "The alternate color used by the animation.",
        DataType = "ColorEnum")]
    public virtual ColorEnum AlternateColor { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Sequence",
        Summary = "The sequence of characters or frames that make up the animation.",
        DataType = "string")]
    public virtual string Sequence { get; set; }
}
