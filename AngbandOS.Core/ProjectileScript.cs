// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class ProjectileScript : IGetKey, IUniversalScript // DO NOT ADD MORE INTERFACES HERE, ADD IT TO THE IPROJECTILE
{
    protected readonly Game Game;
    public ProjectileScript(Game game, ProjectileScriptGameConfiguration projectileScriptGameConfiguration)
    {
        Game = game;
        Key = projectileScriptGameConfiguration.Key ?? projectileScriptGameConfiguration.GetType().Name;
        ProjectileBindingKey = projectileScriptGameConfiguration.ProjectileBindingKey;
        DamageRollExpression = projectileScriptGameConfiguration.DamageRollExpression;
        RadiusRollExpression = projectileScriptGameConfiguration.RadiusRollExpression;
        Stop = projectileScriptGameConfiguration.Stop;
        Kill = projectileScriptGameConfiguration.Kill;
        Jump = projectileScriptGameConfiguration.Jump;
        Beam = projectileScriptGameConfiguration.Beam;
        Grid = projectileScriptGameConfiguration.Grid;
        Item = projectileScriptGameConfiguration.Item;
        Thru = projectileScriptGameConfiguration.Thru;
        Hide = projectileScriptGameConfiguration.Hide;
        Identified = projectileScriptGameConfiguration.Identified;
        PreMessage = projectileScriptGameConfiguration.PreMessage;
        PostMessage = projectileScriptGameConfiguration.PostMessage;
        SmashingOnPetsTurnsUnfriendly = projectileScriptGameConfiguration.SmashingOnPetsTurnsUnfriendly;
        NonDirectionalProjectileMode = projectileScriptGameConfiguration.NonDirectionalProjectileMode;
    }

    public void Bind()
    {
        Projectile = Game.SingletonRepository.Get<Projectile>(ProjectileBindingKey);
        DamageRoll = Game.ParseNumericExpression(DamageRollExpression);
        RadiusRoll = Game.ParseNumericExpression(RadiusRollExpression);
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        ProjectileScriptGameConfiguration projectileScriptGameConfiguration = new ProjectileScriptGameConfiguration()
        {
            Key = Key,
            ProjectileBindingKey = ProjectileBindingKey,
            DamageRollExpression = DamageRollExpression,
            RadiusRollExpression = RadiusRollExpression,
            Stop = Stop,
            Kill = Kill,
            Jump = Jump,
            Beam = Beam,
            Grid = Grid,
            Item = Item,
            Thru = Thru,
            Hide = Hide,
            Identified = Identified,
            PreMessage = PreMessage,
            PostMessage = PostMessage,
            SmashingOnPetsTurnsUnfriendly = SmashingOnPetsTurnsUnfriendly,
            NonDirectionalProjectileMode = NonDirectionalProjectileMode,
        };
        return JsonSerializer.Serialize(projectileScriptGameConfiguration, Game.GetJsonSerializerOptions());
    }

    public string GetKey => Key;

    #region Bounded Properties
    public Expression RadiusRoll { get; protected set; }

    /// <summary>
    /// Returns a roll for the amount of damage the projectile produces.  This property is bound from the <see cref="DamageRollExpression"/> property during the bind phase.
    /// </summary>
    public Expression DamageRoll { get; protected set; }

    /// <summary>
    /// Returns the projectile to use.  This property is bound using the <see cref="ProjectileBindingKey"/> property during the binding phase.
    /// </summary>
    public Projectile Projectile { get; protected set; }
    #endregion

    #region Light-weight virtuals and abstracts for game configuration.
    public virtual string Key { get; }

    /// <summary>
    /// Returns the details that are presented to the player.  Returns the <see cref="Expression.Minimize(MinimizeOptions)"> version of the <see cref="DamageRoll"/>, by default.
    /// </summary>
    public string LearnedDetails => $"dam {DamageRoll.Minimize(new MinimizeOptions()).Text}";

    /// <summary>
    /// Returns the binding key for the projectile.  This property is used to bind the <see cref="Projectile"/> property during the binding phase.
    /// </summary>
    protected virtual string ProjectileBindingKey { get; }

    /// <summary>
    /// Returns a roll expression for the amount of damage the projectile produces.  This property is used to bind the <see cref="DamageRoll"/> property during the bind phase.
    /// </summary>
    protected virtual string DamageRollExpression { get; }

    /// <summary>
    /// Returns a roll expression for the radius of damage the projectile produces.  A radius of 0 represents a bolt.  A radius >0 represents a ball and a radius <0 represents breathe.
    /// Returns zero by default.
    /// </summary>
    protected virtual string RadiusRollExpression { get; } = "0";

    /// <summary>
    /// Causes a projectile or spell to stop when it hits an obstacle, halting further movement or effects along its path.
    /// </summary>
    public virtual bool Stop { get; }

    /// <summary>
    /// Permits the projectile or spell to affect monsters or entities in its path, enabling damage or other targeted effects.
    /// </summary>
    public virtual bool Kill { get; }

    /// <summary>
    /// Allows the projectile or spell to skip directly to the target location, ignoring any intermediate grids or obstacles.
    /// </summary>
    public virtual bool Jump { get; }

    /// <summary>
    /// Causes the effect to travel in a line, potentially hitting multiple targets along a straight path. Useful in corridors or for reaching enemies aligned with the caster.
    /// </summary>
    public virtual bool Beam { get; }

    /// <summary>
    /// Allows the effect to interact with each grid (tile or cell) it moves through, which can alter terrain or affect grid-based elements like traps.
    /// </summary>
    public virtual bool Grid { get; }

    /// <summary>
    /// Enables the effect to interact with items it encounters, possibly damaging or destroying them if applicable.
    /// </summary>
    public virtual bool Item { get; }

    /// <summary>
    /// Lets the effect pass through targets or objects without stopping, continuing on to hit entities or objects further along its trajectory.
    /// </summary>
    public virtual bool Thru { get; }

    /// <summary>
    /// Makes the projectile or spell hidden from the player’s view, often used when visual representation is unnecessary.
    /// </summary>
    public virtual bool Hide { get; }

    /// <summary>
    /// Returns true, if the projectile is automatically identified; false, if the projectile is not identifiable; or null, if the projectile is identified, if and
    /// only if, the projectile hits and affects a monster, item or grid tile.  Returns true, by default.
    /// </summary>
    public virtual bool? Identified { get; } = true;

    /// <summary>
    /// Returns a message to be rendered before the projectile is projected or null, for no message.  Returns null, by default.
    /// </summary>
    public virtual string? PreMessage { get; } = null;

    /// <summary>
    /// Returns a message to be rendered after the projectile is projected or null, for no message.  Returns null, by default.
    /// </summary>
    public virtual string? PostMessage { get; } = null;

    /// <summary>
    /// Returns whether or not this projectile turns a pet into an unfriendly monster, when using the <see cref="ExecuteUnfriendlyScript"/> method.  Returns true, by default.
    /// </summary>
    public virtual bool SmashingOnPetsTurnsUnfriendly { get; } = true;

    /// <summary>
    /// Returns the mode that the projectile will use when it is launched using a script interface that does not accept a directional parameter.
    /// </summary>
    public virtual NonDirectionalProjectileModeEnum NonDirectionalProjectileMode { get; } = NonDirectionalProjectileModeEnum.Default;
    #endregion

    #region Interface Fulfillments - These fulfillments use the private implementations to satisfy the interfaces that the projectiles support.
    public bool ExecuteSuccessByChanceScript()
    {
        IdentifiedAndUsedResult readScrollAndUseStaffResult = ExecuteNonDirectionalWithPreAndPostMessages();
        return readScrollAndUseStaffResult.IsIdentified;
    }

    /// <summary>
    /// Projects the projectile in a given direction and returns true in all cases because there is no user interaction that can result in the player cancelling the script.  The <paramref name="item"/>
    /// parameter is ignored.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    public UsedResult ExecuteDirectionalActivationScript(Item item, int direction)
    {
        ExecuteDirectionalWithPreAndPostMessages(direction);
        return UsedResult.True;
    }

    /// <summary>
    /// Projects the projectile in a given direction using the associated properties.
    /// </summary>
    /// <param name="direction"></param>
    /// <returns>True, if the projectile can be identified by the player; false, otherwise.</returns>
    public IdentifiedResult ExecuteAimWandScript(int direction)
    {
        return ExecuteDirectionalWithPreAndPostMessages(direction);
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
        IdentifiedResult identifiedResult = ExecuteTargeted(direction);
        return new IdentifiedAndUsedResult(identifiedResult, true);
    }

    /// <summary>
    /// Uses the <see cref="NonDirectionalProjectileMode"/> property to project the projectile and return an <see cref="IdentifiedAndUsedResult"/>.
    /// </summary>
    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        return ExecuteNonDirectionalWithPreAndPostMessages();
    }

    /// <summary>
    /// Uses the <see cref="NonDirectionalProjectileMode"/> property to project the projectile and discards the return value.
    /// </summary>
    public void ExecuteScript()
    {
        ExecuteNonDirectionalWithPreAndPostMessages();
    }

    public UsedResult ExecuteActivateItemScript(Item item) // This is run by an item activation
    {
        IdentifiedAndUsedResult readScrollAndUseStaffResult = ExecuteNonDirectionalWithPreAndPostMessages();
        return new UsedResult(readScrollAndUseStaffResult); // TODO: This is lossy
    }

    public bool ExecuteUnfriendlyScript(int who, int y, int x)
    {
        int damage = Game.ComputeIntegerExpression(DamageRoll).Value;
        int radius = Game.ComputeIntegerExpression(RadiusRoll).Value;
        bool affectsMonster = Projectile.Fire(who, radius, y, x, damage, kill: Kill, jump: Jump, hide: Hide, beam: Beam, thru: Thru, grid: Grid, item: Item, stop: Stop);
        return SmashingOnPetsTurnsUnfriendly;
    }

    /// <summary>
    /// Projects the projectile via the <see cref="IScript"/> interface.  The <see cref="IScript"/> interface is used to convert an <see cref="IUniversalScript"/> script into an <see cref="ICastSpellScript"/>.
    /// </summary>
    /// <param name="spell"></param>
    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
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

    /// <summary>
    /// Projects the projectile using the <see cref="NonDirectionalProjectileMode"/> to specify the direction(s).  Also, renders the pre and post messages accordingly.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private IdentifiedAndUsedResult ExecuteNonDirectionalWithPreAndPostMessages()
    {
        switch (NonDirectionalProjectileMode)
        {
            case NonDirectionalProjectileModeEnum.PlayerSpecified:
                {
                    if (!Game.GetDirectionWithAim(out int direction))
                    {
                        return new IdentifiedAndUsedResult(false, false);
                    }
                    RenderPreMessage();
                    IdentifiedResult identifiedResult = ExecuteTargeted(direction);
                    RenderPostMessage();
                    return new IdentifiedAndUsedResult(identifiedResult.IsIdentified, true);
                }
            case NonDirectionalProjectileModeEnum.AllDirections:
                {
                    RenderPreMessage();
                    bool identified = false;
                    foreach (int direction in Game.OrderedDirection)
                    {
                        IdentifiedResult identifiedResult = ExecuteTargeted(direction);
                        if (identifiedResult.IsIdentified)
                        {
                            identified = true;
                        }
                    }
                    RenderPostMessage();
                    return new IdentifiedAndUsedResult(identified, true);
                }
            case NonDirectionalProjectileModeEnum.AllMonstersInLos:
                {
                    RenderPreMessage();
                    bool anyIdentified = false;
                    int damage = Game.ComputeIntegerExpression(DamageRoll).Value;
                    int radius = Game.ComputeIntegerExpression(RadiusRoll).Value;
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
                    RenderPostMessage();
                    return new IdentifiedAndUsedResult(anyIdentified, true);
                }
            case NonDirectionalProjectileModeEnum.AtPlayerLocation:
                {
                    int damage = Game.ComputeIntegerExpression(DamageRoll).Value;
                    int radius = Game.ComputeIntegerExpression(RadiusRoll).Value;
                    RenderPreMessage();
                    bool affectsMonster = Projectile.Fire(0, radius, Game.MapY.IntValue, Game.MapX.IntValue, damage, kill: Kill, jump: Jump, hide: Hide, beam: Beam, thru: Thru, grid: Grid, item: Item, stop: Stop);
                    RenderPostMessage();
                    bool identified = Identified ?? affectsMonster;
                    return new IdentifiedAndUsedResult(identified, true);
                }
            default:
                throw new Exception("Invalid value for NonDirectionalProjectileMode.");
        }
    }

    private IdentifiedResult ExecuteDirectionalWithPreAndPostMessages(int direction)
    {
        RenderPreMessage();
        int radius = Game.ComputeIntegerExpression(RadiusRoll).Value;
        int damage = Game.ComputeIntegerExpression(DamageRoll).Value;
        bool hitSuccess = Projectile.TargetedFire(direction, damage, radius, grid: Grid, item: Item, kill: Kill, jump: Jump, beam: Beam, thru: Thru, hide: Hide, stop: Stop);
        bool isIdentified = Identified ?? hitSuccess;
        RenderPostMessage();
        return new IdentifiedResult(isIdentified);
    }

    private IdentifiedResult ExecuteTargeted(int direction)
    {
        int radius = Game.ComputeIntegerExpression(RadiusRoll).Value;
        int damage = Game.ComputeIntegerExpression(DamageRoll).Value;
        bool hitSuccess = Projectile.TargetedFire(direction, damage, radius, grid: Grid, item: Item, kill: Kill, jump: Jump, beam: Beam, thru: Thru, hide: Hide, stop: Stop);
        bool isIdentified = Identified ?? hitSuccess;
        return new IdentifiedResult(isIdentified);
    }
    #endregion
}

