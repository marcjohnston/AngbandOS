
namespace AngbandOS.Core.Interface.Configuration;

public class ProjectileGraphicGameConfiguration : NonCompositeSingletonGameConfiguration
{
    /// <summary>
    /// Returns the character to be used for the projectile.
    /// </summary>
    public virtual char Character { get; set; }

    /// <summary>
    /// Returns the color to be used for the projectile.
    /// </summary>
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;
}