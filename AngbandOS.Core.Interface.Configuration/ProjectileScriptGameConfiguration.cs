using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ProjectileScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty(
        Title = "Custom Learned Details",
        Summary = "Returns the details revealed to the player when the projectile is learned. When null, the default details are used.",
        DataType = "string?")]
    public virtual string? CustomLearnedDetails { get; set; } = null;

    [ConfigurationProperty(
        Title = "Projectile Binding Key",
        Summary = "Specifies the binding key for the projectile.",
        DataType = "string")]
    public virtual string ProjectileBindingKey { get; set; }

    [ConfigurationProperty(
        Title = "Damage Roll Expression",
        Summary = "Specifies the roll expression for the amount of damage produced by the projectile.",
        DataType = "string")]
    public virtual string DamageRollExpression { get; set; }

    [ConfigurationProperty(
        Title = "Radius Roll Expression",
        Summary = "Specifies the roll expression for the projectile's damage radius. A radius of zero represents a bolt, a positive radius represents a ball, and a negative radius represents a breath attack.",
        DataType = "string")]
    public virtual string RadiusRollExpression { get; set; } = "0";

    [ConfigurationProperty(
        Title = "Stop",
        Summary = "Determines whether the projectile stops when it hits an obstacle.",
        DataType = "bool")]
    public virtual bool Stop { get; set; } = false;

    [ConfigurationProperty(
        Title = "Kill",
        Summary = "Determines whether the projectile can affect monsters or other entities in its path.",
        DataType = "bool")]
    public virtual bool Kill { get; set; } = false;

    [ConfigurationProperty(
        Title = "Jump",
        Summary = "Determines whether the projectile moves directly to its target while ignoring intermediate grids or obstacles.",
        DataType = "bool")]
    public virtual bool Jump { get; set; } = false;

    [ConfigurationProperty(
        Title = "Beam",
        Summary = "Determines whether the projectile travels in a line and can affect multiple targets along its path.",
        DataType = "bool")]
    public virtual bool Beam { get; set; } = false;

    [ConfigurationProperty(
        Title = "Grid",
        Summary = "Determines whether the projectile interacts with each grid through which it travels.",
        DataType = "bool")]
    public virtual bool Grid { get; set; } = false;

    [ConfigurationProperty(
        Title = "Item",
        Summary = "Determines whether the projectile interacts with items it encounters.",
        DataType = "bool")]
    public virtual bool Item { get; set; } = false;

    [ConfigurationProperty(
        Title = "Thru",
        Summary = "Determines whether the projectile passes through targets or objects without stopping.",
        DataType = "bool")]
    public virtual bool Thru { get; set; } = false;

    [ConfigurationProperty(
        Title = "Hide",
        Summary = "Determines whether the projectile is hidden from the player's view.",
        DataType = "bool")]
    public virtual bool Hide { get; set; } = false;

    [ConfigurationProperty(
        Title = "Identified",
        Summary = "Determines whether the projectile is automatically identified. Null indicates conditional identification when the projectile affects a target.",
        DataType = "bool?")]
    public virtual bool? Identified { get; set; } = true;

    [ConfigurationProperty(
        Title = "Pre-Message",
        Summary = "Specifies the message rendered before the projectile is projected. When null, no message is rendered.",
        DataType = "string?")]
    public virtual string? PreMessage { get; set; } = null;

    [ConfigurationProperty(
        Title = "Post-Message",
        Summary = "Specifies the message rendered after the projectile is projected. When null, no message is rendered.",
        DataType = "string?")]
    public virtual string? PostMessage { get; set; } = null;

    [ConfigurationProperty(
        Title = "Smashing On Pets Turns Unfriendly",
        Summary = "Determines whether smashing a pet with the projectile turns the pet into an unfriendly monster.",
        DataType = "bool")]
    public virtual bool SmashingOnPetsTurnsUnfriendly { get; set; } = true;

    [ConfigurationProperty(
        Title = "Non-Directional Projectile Mode",
        Summary = "Specifies the mode used when the projectile is launched without a directional parameter.",
        DataType = "NonDirectionalProjectileModeEnum")]
    public virtual NonDirectionalProjectileModeEnum NonDirectionalProjectileMode { get; set; } = NonDirectionalProjectileModeEnum.Default;
}
