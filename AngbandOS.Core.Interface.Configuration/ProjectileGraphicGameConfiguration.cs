using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ProjectileGraphicGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("char",
        Title = "Character",
        Description = "Specifies the character used to render the projectile.")]
    public virtual char Character { get; set; }

    [ConfigurationProperty("ColorEnum",
        Title = "Color",
        Description = "Specifies the color used to render the projectile.")]
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;
}