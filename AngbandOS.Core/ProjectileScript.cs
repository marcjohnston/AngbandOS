// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;


[Serializable]
internal abstract class ProjectileScript : IGetKey, IProjectile
{
    protected readonly Game Game;
    public ProjectileScript(Game game) 
    {
        Game = game;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
 
    public void Bind()
    {
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

    /// <summary>
    /// Returns a message to be rendered after the projectile is projected or null, for no message.  Returns null, by default.
    /// </summary>
    public virtual string? PostMessage => null;

    public virtual NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.Default;

    #region Interface Implementations
    public bool ExecuteSuccessByChanceScript()
    {
        return ExecuteScriptWithPreAndPostMessages<bool>(() =>
        {
            IdentifiedAndUsedResult readScrollAndUseStaffResult = ExecuteNonDirectional();
            return readScrollAndUseStaffResult.IsIdentified;
        });
    }

    /// <summary>
    /// Projects the projectile in a given direction and returns true in all cases because there is no user interaction that can result in the player cancelling the script.  The <paramref name="item"/>
    /// parameter is ignored.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    public bool ExecuteDirectionalActivationScript(Item item, int direction)
    {
        return ExecuteScriptWithPreAndPostMessages<bool>(() =>
        {
            ExecuteTargeted(direction);
            return true; // Return true because the script was not cancelled.
        });
    }

    /// <summary>
    /// Projects the projectile in a given direction using the associated properties.
    /// </summary>
    /// <param name="direction"></param>
    /// <returns>True, if the projectile can be identified by the player; false, otherwise.</returns>
    public bool ExecuteIdentifiedScriptDirection(int direction)
    {
        return ExecuteScriptWithPreAndPostMessages<bool>(() =>
        {
            return ExecuteTargeted(direction);
        });
    }

    /// <summary>
    /// Projects the projectile and returns whether the projectile can be identified by the player and true for used because projectiles are always used.
    /// </summary>
    /// <returns>
    /// identified:description: returns true, if the projectile actually hits and affects a monster, which allows the projectile to be identified by the player; false, otherwise.
    /// used:description: returns true if the projectile uses a charge for rod items
    /// </returns>
    public IdentifiedAndUsedResult ExecuteZapRodScript(Item item, int direction)
    {
        return ExecuteScriptWithPreAndPostMessages<IdentifiedAndUsedResult>(() =>
        {
            bool isIdentified = ExecuteTargeted(direction);
            return new IdentifiedAndUsedResult(isIdentified, true);
        });
    }

    /// <summary>
    /// Projects the projectile in a direction specified by the <see cref="NonDirectionalProjectileMode"/> property.
    /// </summary>
    public IdentifiedAndUsedResult ExecuteReadScrollAndUseStaffScript()
    {
        return ExecuteScriptWithPreAndPostMessages<IdentifiedAndUsedResult>(() =>
        {
            return ExecuteNonDirectional();
        });
    }

    public void ExecuteScript()
    {
        ExecuteScriptWithPreAndPostMessages(() =>
        {
            ExecuteNonDirectional();
        });
    }

    public bool ExecuteUsedScriptItem(Item item) // This is run by an item activation
    {
        return ExecuteScriptWithPreAndPostMessages<bool>(() =>
        {
            IdentifiedAndUsedResult readScrollAndUseStaffResult = ExecuteNonDirectional();
            return readScrollAndUseStaffResult.IsUsed;
        });
    }
    #endregion

    #region Privates - Implement the functionality.
    private void RenderPreMessage()
    {
        if (PreMessage != null)
        {
            Game.MsgPrint(PreMessage);
        }
    }

    private void RenderPostMessage()
    {
        if (PostMessage != null)
        {
            Game.MsgPrint(PostMessage);
        }
    }

    private T ExecuteScriptWithPreAndPostMessages<T>(Func<T> action)
    {
        RenderPreMessage();
        T result = action();
        RenderPostMessage();
        return result;
    }

    private void ExecuteScriptWithPreAndPostMessages(Action action)
    {
        RenderPreMessage();
        action();
        RenderPostMessage();
    }

    private IdentifiedAndUsedResult ExecuteNonDirectional()
    {
        switch (NonDirectionalProjectileMode)
        {
            case NonDirectionalProjectileModeEnum.PlayerSpecified:
                {
                    if (!Game.GetDirectionWithAim(out int direction))
                    {
                        return new IdentifiedAndUsedResult(false, false);
                    }
                    bool identified = ExecuteIdentifiedScriptDirection(direction);
                    return new IdentifiedAndUsedResult(identified, true);
                }
            case NonDirectionalProjectileModeEnum.AllDirections:
                {
                    bool identified = false;
                    foreach (int direction in Game.OrderedDirection)
                    {
                        if (ExecuteIdentifiedScriptDirection(direction))
                        {
                            identified = true;
                        }
                    }
                    return new IdentifiedAndUsedResult(identified, true);
                }
            case NonDirectionalProjectileModeEnum.AllMonstersInLos:
                {
                    bool anyIdentified = false;
                    int damage = DamageRoll.Get(Game.UseRandom);
                    int radius = RadiusRoll.Get(Game.UseRandom);
                    for (int i = 1; i < Game.MonsterMax; i++)
                    {
                        Monster mPtr = Game.Monsters[i];
                        if (mPtr.Race == null) // TODO: This should never be.
                        {
                            continue;
                        }
                        int y = mPtr.MapY;
                        int x = mPtr.MapX;
                        if (!Game.PlayerHasLosBold(y, x))
                        {
                            continue;
                        }
                        bool affectsMonster = Projectile.Fire(0, radius, y, x, damage, kill: Kill, jump: Jump, hide: Hide, beam: Beam, thru: Thru, grid: Grid, item: Item, stop: Stop);
                        bool identified = Identified ?? affectsMonster;
                        if (identified)
                        {
                            anyIdentified = true;
                        }
                    }
                    return new IdentifiedAndUsedResult(anyIdentified, true);
                }
            default:
                throw new Exception("Invalid value for NonDirectionalProjectileMode.");
        }
    }

    private bool ExecuteTargeted(int direction)
    {
        int radius = RadiusRoll.Get(Game.UseRandom);
        int damage = DamageRoll.Get(Game.UseRandom);
        bool hitSuccess = Projectile.TargetedFire(direction, damage, radius, grid: Grid, item: Item, kill: Kill, jump: Jump, beam: Beam, thru: Thru, hide: Hide, stop: Stop);
        return Identified ?? hitSuccess;
    }
    #endregion
}

