using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ProjectileGraphicGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Character",
        Summary = "Specifies the character used to render the projectile.",
        DataType = "char")]
    public virtual char Character { get; set; }

    [ConfigurationMetadata(
        Title = "Color",
        Summary = "Specifies the color used to render the projectile.",
        DataType = "ColorEnum")]
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;
}