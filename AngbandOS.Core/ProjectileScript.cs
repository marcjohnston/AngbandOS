// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal abstract class ProjectileScript : Script, IDirectionalCancellableScriptItem, IIdentifableDirectionalScript, IIdentifiedAndUsedScriptItemDirection, IScript
{
    public ProjectileScript(Game game) : base(game) { }

    public override void Bind()
    {
        base.Bind();
        Projectile = Game.SingletonRepository.Get<Projectile>(ProjectileBindingKey);
        DamageRoll = Game.ParseRollExpression(DamageRollExpression);
        RadiusRoll = Game.ParseRollExpression(RadiusRollExpression);
    }

    protected virtual string ProjectileBindingKey { get; }

    public Projectile Projectile { get; protected set; }

    /// <summary>
    /// Returns a roll expression for the amount of damage the projectile produces.
    /// </summary>
    protected abstract string DamageRollExpression { get; }

    public Roll DamageRoll { get; protected set; }

    /// <summary>
    /// Returns a roll expression for the radius of damage the projectile produces.  A radius of 0 represents a bolt.  A radius >0 represents a ball and a radius <0 represents breathe.
    /// Returns zero by default.
    /// </summary>
    protected virtual string RadiusRollExpression => "0";

    public Roll RadiusRoll { get; protected set; }

    /// <summary>
    /// Causes a projectile or spell to stop when it hits an obstacle, halting further movement or effects along its path.
    /// </summary>
    public abstract bool Stop { get; }

    /// <summary>
    /// Permits the projectile or spell to affect monsters or entities in its path, enabling damage or other targeted effects.
    /// </summary>
    public abstract bool Kill { get; }

    /// <summary>
    /// Allows the projectile or spell to skip directly to the target location, ignoring any intermediate grids or obstacles.
    /// </summary>
    public abstract bool Jump { get; }

    /// <summary>
    /// Causes the effect to travel in a line, potentially hitting multiple targets along a straight path. Useful in corridors or for reaching enemies aligned with the caster.
    /// </summary>
    public abstract bool Beam { get; }

    /// <summary>
    /// Allows the effect to interact with each grid (tile or cell) it moves through, which can alter terrain or affect grid-based elements like traps.
    /// </summary>
    public abstract bool Grid { get; }

    /// <summary>
    /// Enables the effect to interact with items it encounters, possibly damaging or destroying them if applicable.
    /// </summary>
    public abstract bool Item { get; }

    /// <summary>
    /// Lets the effect pass through targets or objects without stopping, continuing on to hit entities or objects further along its trajectory.
    /// </summary>
    public abstract bool Thru { get; }

    /// <summary>
    /// Makes the projectile or spell hidden from the player’s view, often used when visual representation is unnecessary.
    /// </summary>
    public abstract bool Hide { get; }

    /// <summary>
    /// Returns true, if the projectile is automatically identified; false, if the projectile is not identifiable; or null, if the projectile is identified, if and
    /// only if, the projectile hits and affects a monster, item or grid tile.  Returns true, by default.
    /// </summary>
    public virtual bool? Identified => true;

    /// <summary>
    /// Returns a message to be rendered before the projectile is projected or null, for no message.  Returns null, by default.
    /// </summary>
    public virtual string? PreMessage => null;

    public virtual NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.Default;

    /// <summary>
    /// Projects the projectile and returns true in all cases because there is no user interaction that can result in the player cancelling the script.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    public bool ExecuteCancellableScriptItem(Item item, int direction)
    {
        ExecuteIdentifableDirectionalScript(direction);
        return true; // Return true because the script was not cancelled.
    }

    /// <summary>
    /// Projects the projectile and returns true, if the projectile is identifable by the player; false, otherwise.
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    public bool ExecuteIdentifableDirectionalScript(int direction)
    {
        int radius = RadiusRoll.Get(Game.UseRandom);
        int damage = DamageRoll.Get(Game.UseRandom);
        bool hitSuccess = Projectile.TargetedFire(direction, damage, radius, grid: Grid, item: Item, kill: Kill, jump: Jump, beam: Beam, thru: Thru, hide: Hide, stop: Stop);
        return Identified ?? hitSuccess;
    }

    /// <summary>
    /// Projects the projectile and returns whether the projectile can be identified and whether the projectile actually used a consumable.
    /// </summary>
    /// <returns>
    /// identified:description: returns true, if the projectile actually hits and affects a monster, which allows the projectile to be identified by the player; false, otherwise.
    /// used:description: returns true if the projectile uses a charge for rod items
    /// </returns>
    public (bool identified, bool used) ExecuteIdentifiedAndUsedScriptItemDirection(Item item, int dir)
    {
        if (PreMessage != null)
        {
            Game.MsgPrint(PreMessage);
        }

        bool identified = ExecuteIdentifableDirectionalScript(dir);
        return (identified, true);
    }

    /// <summary>
    /// Gets a direction from the player and projects the projectile in the specified direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        switch (NonDirectionalProjectileMode)
        {
            case NonDirectionalProjectileModeEnum.PlayerSpecified:
                {
                    if (!Game.GetDirectionWithAim(out int dir))
                    {
                        return;
                    }
                    ExecuteIdentifableDirectionalScript(dir);
                }
                break;
            case NonDirectionalProjectileModeEnum.AllDirections:
                {
                    foreach (int dir in Game.OrderedDirection)
                    {
                        ExecuteIdentifableDirectionalScript(dir);
                    }
                }
                break;
            //case NonDirectionalProjectileModeEnum.MonstersInLos:
            //    {
            //    }
            //    break;
            default:
                throw new Exception("Invalid value for NonDirectionalProjectileMode.");
        }
    }
}
