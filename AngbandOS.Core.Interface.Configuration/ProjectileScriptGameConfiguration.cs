namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ProjectileScriptGameConfiguration
{
    public virtual string? Key { get; set; } = null;
    /// <summary>
    /// Returns the binding key for the projectile.  This property is used to bind the <see cref="Projectile"/> property during the binding phase.
    /// </summary>
    public virtual string ProjectileBindingKey { get; set; }

    /// <summary>
    /// Returns a roll expression for the amount of damage the projectile produces.  This property is used to bind the <see cref="DamageRoll"/> property during the bind phase.
    /// </summary>
    public virtual string DamageRollExpression { get; set; }
    /// <summary>
    /// Returns a roll expression for the radius of damage the projectile produces.  A radius of 0 represents a bolt.  A radius >0 represents a ball and a radius <0 represents breathe.
    /// Returns zero by default.
    /// </summary>
    public virtual string RadiusRollExpression { get; set; } = "0";

    /// <summary>
    /// Causes a projectile or spell to stop when it hits an obstacle, halting further movement or effects along its path.
    /// </summary>
    public virtual bool Stop { get; set; }

    /// <summary>
    /// Permits the projectile or spell to affect monsters or entities in its path, enabling damage or other targeted effects.
    /// </summary>
    public virtual bool Kill { get; set; }

    /// <summary>
    /// Allows the projectile or spell to skip directly to the target location, ignoring any intermediate grids or obstacles.
    /// </summary>
    public virtual bool Jump { get; set; }

    /// <summary>
    /// Causes the effect to travel in a line, potentially hitting multiple targets along a straight path. Useful in corridors or for reaching enemies aligned with the caster.
    /// </summary>
    public virtual bool Beam { get; set; }

    /// <summary>
    /// Allows the effect to interact with each grid (tile or cell) it moves through, which can alter terrain or affect grid-based elements like traps.
    /// </summary>
    public virtual bool Grid { get; set; }

    /// <summary>
    /// Enables the effect to interact with items it encounters, possibly damaging or destroying them if applicable.
    /// </summary>
    public virtual bool Item { get; set; }

    /// <summary>
    /// Lets the effect pass through targets or objects without stopping, continuing on to hit entities or objects further along its trajectory.
    /// </summary>
    public virtual bool Thru { get; set; }

    /// <summary>
    /// Makes the projectile or spell hidden from the player’s view, often used when visual representation is unnecessary.
    /// </summary>
    public virtual bool Hide { get; set; }

    /// <summary>
    /// Returns true, if the projectile is automatically identified; false, if the projectile is not identifiable; or null, if the projectile is identified, if and
    /// only if, the projectile hits and affects a monster, item or grid tile.  Returns true, by default.
    /// </summary>
    public virtual bool? Identified { get; set; } = true;

    /// <summary>
    /// Returns a message to be rendered before the projectile is projected or null, for no message.  Returns null, by default.
    /// </summary>
    public virtual string? PreMessage { get; set; } = null;

    /// <summary>
    /// Returns a message to be rendered after the projectile is projected or null, for no message.  Returns null, by default.
    /// </summary>
    public virtual string? PostMessage { get; set; } = null;

    /// <summary>
    /// Returns whether or not this projectile turns a pet into an unfriendly monster, when using the <see cref="ExecuteUnfriendlyScript"/> method.  Returns true, by default.
    /// </summary>
    public virtual bool SmashingOnPetsTurnsUnfriendly { get; set; } = true;

    /// <summary>
    /// Returns the mode that the projectile will use when it is launched using a script interface that does not accept a directional parameter.
    /// </summary>
    public virtual NonDirectionalProjectileModeEnum NonDirectionalProjectileMode { get; set; } = NonDirectionalProjectileModeEnum.Default;
}
