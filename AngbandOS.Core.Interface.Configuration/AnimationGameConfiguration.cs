using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class AnimationGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("char",
        Title = "Character",
        Description = "The character displayed by the animation.")]
    public virtual char Character { get; set; }

    [ConfigurationProperty("ColorEnum",
        Title = "Color",
        Description = "The primary color used by the animation.")]
    public virtual ColorEnum Color { get; set; }

    [ConfigurationProperty("string",
        Title = "Name",
        Description = "The name of the animation.")]
    public virtual string Name { get; set; }

    [ConfigurationProperty("ColorEnum",
        Title = "Alternate Color",
        Description = "The alternate color used by the animation.")]
    public virtual ColorEnum AlternateColor { get; set; }

    [ConfigurationProperty("string",
        Title = "Sequence",
        Description = "The sequence of characters or frames that make up the animation.")]
    public virtual string Sequence { get; set; }
}
