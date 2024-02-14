namespace AngbandOS.Core.Interface.Definitions;

[Serializable]
public class ProjectileGraphicDefinition : IPoco
{
    public virtual string Key { get; set; }

    /// <summary>
    /// Returns the character to be used for the projectile.
    /// </summary>
    public virtual char Character { get; set; }

    /// <summary>
    /// Returns the color to be used for the projectile.
    /// </summary>
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    public bool IsValid()
    {
        return true;
    }
}