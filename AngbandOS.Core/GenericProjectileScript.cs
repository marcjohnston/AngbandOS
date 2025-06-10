// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Configuration;
namespace AngbandOS.Core;

[Serializable]
internal class GenericProjectileScript : ProjectileScript
{
    public GenericProjectileScript(Game game, ProjectileScriptGameConfiguration projectileScriptGameConfiguration) : base(game)
    {
        Key = projectileScriptGameConfiguration.Key ?? projectileScriptGameConfiguration.GetType().Name;
        ProjectileBindingKey  = projectileScriptGameConfiguration.ProjectileBindingKey;
        DamageRollExpression  = projectileScriptGameConfiguration.DamageRollExpression;
        RadiusRollExpression  = projectileScriptGameConfiguration.RadiusRollExpression;
        Stop  = projectileScriptGameConfiguration.Stop;
        Kill  = projectileScriptGameConfiguration.Kill;
        Jump  = projectileScriptGameConfiguration.Jump;
        Beam  = projectileScriptGameConfiguration.Beam;
        Grid  = projectileScriptGameConfiguration.Grid;
        Item  = projectileScriptGameConfiguration.Item;
        Thru  = projectileScriptGameConfiguration.Thru;
        Hide  = projectileScriptGameConfiguration.Hide;
        Identified = projectileScriptGameConfiguration.Identified;
        PreMessage = projectileScriptGameConfiguration.PreMessage;
        PostMessage   = projectileScriptGameConfiguration.PostMessage;
        SmashingOnPetsTurnsUnfriendly  = projectileScriptGameConfiguration.SmashingOnPetsTurnsUnfriendly;
        NonDirectionalProjectileMode = projectileScriptGameConfiguration.NonDirectionalProjectileMode;
  }

    public override string Key { get; }
    /// <summary>
    /// Returns the binding key for the projectile.  This property is used to bind the <see cref="Projectile"/> property during the binding phase.
    /// </summary>
    protected override string ProjectileBindingKey { get; }

    /// <summary>
    /// Returns a roll expression for the amount of damage the projectile produces.  This property is used to bind the <see cref="DamageRoll"/> property during the bind phase.
    /// </summary>
    protected override string DamageRollExpression { get; }
    /// <summary>
    /// Returns a roll expression for the radius of damage the projectile produces.  A radius of 0 represents a bolt.  A radius >0 represents a ball and a radius <0 represents breathe.
    /// Returns zero by default.
    /// </summary>
    protected override string RadiusRollExpression { get; } = "0";

    /// <summary>
    /// Causes a projectile or spell to stop when it hits an obstacle, halting further movement or effects along its path.
    /// </summary>
    public override bool Stop { get; }

    /// <summary>
    /// Permits the projectile or spell to affect monsters or entities in its path, enabling damage or other targeted effects.
    /// </summary>
    public override bool Kill { get; }

    /// <summary>
    /// Allows the projectile or spell to skip directly to the target location, ignoring any intermediate grids or obstacles.
    /// </summary>
    public override bool Jump { get; }

    /// <summary>
    /// Causes the effect to travel in a line, potentially hitting multiple targets along a straight path. Useful in corridors or for reaching enemies aligned with the caster.
    /// </summary>
    public override bool Beam { get; }

    /// <summary>
    /// Allows the effect to interact with each grid (tile or cell) it moves through, which can alter terrain or affect grid-based elements like traps.
    /// </summary>
    public override bool Grid { get; }

    /// <summary>
    /// Enables the effect to interact with items it encounters, possibly damaging or destroying them if applicable.
    /// </summary>
    public override bool Item { get; }

    /// <summary>
    /// Lets the effect pass through targets or objects without stopping, continuing on to hit entities or objects further along its trajectory.
    /// </summary>
    public override bool Thru { get; }

    /// <summary>
    /// Makes the projectile or spell hidden from the player’s view, often used when visual representation is unnecessary.
    /// </summary>
    public override bool Hide { get; }

    /// <summary>
    /// Returns true, if the projectile is automatically identified; false, if the projectile is not identifiable; or null, if the projectile is identified, if and
    /// only if, the projectile hits and affects a monster, item or grid tile.  Returns true, by default.
    /// </summary>
    public override bool? Identified { get; } = true;

    /// <summary>
    /// Returns a message to be rendered before the projectile is projected or null, for no message.  Returns null, by default.
    /// </summary>
    public override string? PreMessage { get; } = null;

    /// <summary>
    /// Returns a message to be rendered after the projectile is projected or null, for no message.  Returns null, by default.
    /// </summary>
    public override string? PostMessage { get; } = null;

    /// <summary>
    /// Returns whether or not this projectile turns a pet into an unfriendly monster, when using the <see cref="ExecuteUnfriendlyScript"/> method.  Returns true, by default.
    /// </summary>
    public override bool SmashingOnPetsTurnsUnfriendly { get; } = true;

    /// <summary>
    /// Returns the mode that the projectile will use when it is launched using a script interface that does not accept a directional parameter.
    /// </summary>
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode { get; } = NonDirectionalProjectileModeEnum.Default;
}

