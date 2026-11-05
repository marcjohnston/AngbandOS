using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class AnimationGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationPropertyAttribute(
        Title = "Character",
        Summary = "The character displayed by the animation.",
        DataType = "char")]
    public virtual char Character { get; set; }

    [ConfigurationPropertyAttribute(
        Title = "Color",
        Summary = "The primary color used by the animation.",
        DataType = "ColorEnum")]
    public virtual ColorEnum Color { get; set; }

    [ConfigurationPropertyAttribute(
        Title = "Name",
        Summary = "The name of the animation.",
        DataType = "string")]
    public virtual string Name { get; set; }

    [ConfigurationPropertyAttribute(
        Title = "Alternate Color",
        Summary = "The alternate color used by the animation.",
        DataType = "ColorEnum")]
    public virtual ColorEnum AlternateColor { get; set; }

    [ConfigurationPropertyAttribute(
        Title = "Sequence",
        Summary = "The sequence of characters or frames that make up the animation.",
        DataType = "string")]
    public virtual string Sequence { get; set; }
}
