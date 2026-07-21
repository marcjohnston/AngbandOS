// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents a monster spell that fires a projectile without any radius.  Default messages are provided.
/// </summary>
internal sealed class ProjectileMonsterSpell : MonsterSpell
{
    public ProjectileMonsterSpell(Game game, ProjectileMonsterSpellGameConfiguration gameConfiguration) : base(game)
    {
        Key = gameConfiguration.GetKey;
        IsInnate = gameConfiguration.IsInnate;
        IsIntelligent = gameConfiguration.IsIntelligent;
        UsesAcid = gameConfiguration.UsesAcid;
        UsesLightning = gameConfiguration.UsesLightning;
        UsesFire = gameConfiguration.UsesFire;
        UsesCold = gameConfiguration.UsesCold;
        UsesPoison = gameConfiguration.UsesPoison;
        UsesRadiation = gameConfiguration.UsesRadiation;
        UsesNether = gameConfiguration.UsesNether;
        UsesLight = gameConfiguration.UsesLight;
        UsesDarkness = gameConfiguration.UsesDarkness;
        UsesFear = gameConfiguration.UsesFear;
        UsesConfusion = gameConfiguration.UsesConfusion;
        UsesBreathe = gameConfiguration.UsesBreathe;
        UsesChaos = gameConfiguration.UsesChaos;
        UsesDisenchantment = gameConfiguration.UsesDisenchantment;
        UsesBlindness = gameConfiguration.UsesBlindness;
        UsesNexus = gameConfiguration.UsesNexus;
        UsesSound = gameConfiguration.UsesSound;
        UsesShards = gameConfiguration.UsesShards;
        CanBeReflected = gameConfiguration.CanBeReflected;
        RestrictsFreeAction = gameConfiguration.RestrictsFreeAction;
        DrainsMana = gameConfiguration.DrainsMana;
        SummonsHelp = gameConfiguration.SummonsHelp;
        ProvidesEscape = gameConfiguration.ProvidesEscape;
        Heals = gameConfiguration.Heals;
        IsAttack = gameConfiguration.IsAttack;
        IsTactical = gameConfiguration.IsTactical;
        Hastens = gameConfiguration.Hastens;
        Annoys = gameConfiguration.Annoys;
        VsPlayerBlindMessage = gameConfiguration.VsPlayerBlindMessage;
        VsPlayerActionMessage = gameConfiguration.VsPlayerActionMessage;
        VsPlayerActionMessageOnInvisibleMonster = gameConfiguration.VsPlayerActionMessageOnInvisibleMonster;
        VsMonsterUnseenMessage = gameConfiguration.VsMonsterUnseenMessage;
        VsMonsterSeenMessage = gameConfiguration.VsMonsterSeenMessage;
        SmartLearnSpellResistantDetectionKeys = gameConfiguration.SmartLearnSpellResistantDetectionKeys;
        WakesSleepingMonsters = gameConfiguration.WakesSleepingMonsters;
        ItemProjectionFlag = gameConfiguration.ItemProjectionFlag;
        GridProjectionFlag = gameConfiguration.GridProjectionFlag;
        KillProjectionFlag = gameConfiguration.KillProjectionFlag;
        StopProjectionFlag = gameConfiguration.StopProjectionFlag;
        ProjectileKey = gameConfiguration.ProjectileKey;
        MaxDamage = gameConfiguration.MaxDamage;
        DamageRollExpression = gameConfiguration.DamageRollExpression;
        InverseRadius = gameConfiguration.InverseRadius;
        RadiusExpressionText = gameConfiguration.RadiusExpressionText;
        PreExecuteOnPlayerScriptBindingKey = gameConfiguration.PreExecuteOnPlayerScriptBindingKey;
        PostExecuteOnPlayerScriptBindingKey = gameConfiguration.PostExecuteOnPlayerScriptBindingKey;
        PreExecuteOnMonsterScriptBindingKey = gameConfiguration.PreExecuteOnMonsterScriptBindingKey;
        PostExecuteOnMonsterScriptBindingKey = gameConfiguration.PostExecuteOnMonsterScriptBindingKey;
        KnowledgeAction = gameConfiguration.KnowledgeAction;
   }
    public override string ToJson()
    {
        ProjectileMonsterSpellGameConfiguration definition = new()
        {
            Key = Key,
            IsInnate = IsInnate,
            IsIntelligent = IsIntelligent,
            UsesAcid = UsesAcid,
            UsesLightning = UsesLightning,
            UsesFire = UsesFire,
            UsesCold = UsesCold,
            UsesPoison = UsesPoison,
            UsesRadiation = UsesRadiation,
            UsesNether = UsesNether,
            UsesLight = UsesLight,
            UsesDarkness = UsesDarkness,
            UsesFear = UsesFear,
            UsesConfusion = UsesConfusion,
            UsesBreathe = UsesBreathe,
            UsesChaos = UsesChaos,
            UsesDisenchantment = UsesDisenchantment,
            UsesBlindness = UsesBlindness,
            UsesNexus = UsesNexus,
            UsesSound = UsesSound,
            UsesShards = UsesShards,
            CanBeReflected = CanBeReflected,
            RestrictsFreeAction = RestrictsFreeAction,
            DrainsMana = DrainsMana,
            SummonsHelp = SummonsHelp,
            ProvidesEscape = ProvidesEscape,
            Heals = Heals,
            IsAttack = IsAttack,
            IsTactical = IsTactical,
            Hastens = Hastens,
            Annoys = Annoys,
            VsPlayerBlindMessage = VsPlayerBlindMessage,
            VsPlayerActionMessage = VsPlayerActionMessage,
            VsPlayerActionMessageOnInvisibleMonster = VsPlayerActionMessageOnInvisibleMonster,
            VsMonsterUnseenMessage = VsMonsterUnseenMessage,
            VsMonsterSeenMessage = VsMonsterSeenMessage,
            SmartLearnSpellResistantDetectionKeys = SmartLearnSpellResistantDetectionKeys,
            WakesSleepingMonsters = WakesSleepingMonsters,
            ItemProjectionFlag = ItemProjectionFlag,
            GridProjectionFlag = GridProjectionFlag,
            KillProjectionFlag = KillProjectionFlag,
            StopProjectionFlag = StopProjectionFlag,
            ProjectileKey = ProjectileKey,
            MaxDamage = MaxDamage,
            DamageRollExpression = DamageRollExpression,
            InverseRadius = InverseRadius,
            RadiusExpressionText = RadiusExpressionText,
            PreExecuteOnPlayerScriptBindingKey = PreExecuteOnPlayerScriptBindingKey,
            PostExecuteOnPlayerScriptBindingKey = PostExecuteOnPlayerScriptBindingKey,
            PreExecuteOnMonsterScriptBindingKey = PreExecuteOnMonsterScriptBindingKey,
            PostExecuteOnMonsterScriptBindingKey = PostExecuteOnMonsterScriptBindingKey,
            KnowledgeAction = KnowledgeAction,
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }
    public override string Key { get; }
    public override (string, string) KnowledgeAction { get; }
    public override bool IsInnate { get; } 
    public override bool IsIntelligent { get; }
    public override bool UsesAcid { get; }
    public override bool UsesLightning { get; }
    public override bool UsesFire { get; }
    public override bool UsesCold { get; }
    public override bool UsesPoison { get; }
    public override bool UsesRadiation { get; }
    public override bool UsesNether { get; }
    public override bool UsesLight { get; }
    public override bool UsesDarkness { get; }
    public override bool UsesFear { get; }
    public override bool UsesConfusion { get; }
    public override bool UsesBreathe { get; }
    public override bool UsesChaos { get; }
    public override bool UsesDisenchantment { get; }
    public override bool UsesBlindness { get; }
    public override bool UsesNexus { get; }
    public override bool UsesSound { get; }
    public override bool UsesShards { get; }
    public override bool CanBeReflected { get; }
    public override bool RestrictsFreeAction { get; }
    public override bool DrainsMana { get; }
    public override bool SummonsHelp { get; }
    public override bool ProvidesEscape { get; }
    public override bool Heals { get; }
    public override bool IsAttack { get; }
    public override bool IsTactical { get; }
    public override bool Hastens { get; }
    public override bool Annoys { get; }
    public override string? VsPlayerBlindMessage { get; }
    public override string? VsPlayerActionMessage { get; }
    public override string? VsPlayerActionMessageOnInvisibleMonster { get; }
    public override string? VsMonsterUnseenMessage { get; }
    public override string? VsMonsterSeenMessage { get; }
    protected override string[]? SmartLearnSpellResistantDetectionKeys { get; }
    public override bool WakesSleepingMonsters { get; }

    public override void Bind(RestoreGameState? restoreGameState)
    {
        base.Bind(restoreGameState);
        Projectile = Game.SingletonRepository.Get<Projectile>(ProjectileKey);
        DamageRoll = Game.ParseNumericExpression(DamageRollExpression);
        RadiusExpression = Game.ParseNumericExpression(RadiusExpressionText);
        PreExecuteOnPlayerScript = Game.SingletonRepository.GetNullable<IScriptMonster>(PreExecuteOnPlayerScriptBindingKey);
        PreExecuteOnPlayerScript = Game.SingletonRepository.GetNullable<IScriptMonster>(PostExecuteOnPlayerScriptBindingKey);
        PreExecuteOnMonsterScript = Game.SingletonRepository.GetNullable<IScriptMonsterMonster>(PreExecuteOnMonsterScriptBindingKey);
        PreExecuteOnMonsterScript = Game.SingletonRepository.GetNullable<IScriptMonsterMonster>(PostExecuteOnMonsterScriptBindingKey);
    }

    protected bool ItemProjectionFlag { get; }
    protected bool GridProjectionFlag { get; }
    protected bool KillProjectionFlag { get; }
    protected bool StopProjectionFlag { get; }

    /// <summary>
    /// Returns the key for the projectile to use.  This property is used to bind the ProjectileProperty during the binding phase.
    /// </summary>
    protected string ProjectileKey { get; }

    /// <summary>
    /// Returns the projectile that the monster will use when attacking with the spell.  This property is bound using the ProjectileKey property during the bind phase.
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    protected Projectile Projectile { get; private set; }

    private (string, object)[] GetExpressionProviders(Monster monster) => new (string, object)[] 
    {
        (nameof(ExpressionProvidersEnum.MonsterLevel), Math.Max(monster.Race.Level, 1)),
        (nameof(ExpressionProvidersEnum.MonsterHealth), monster.Health)
    };

    protected int Damage(Monster monster)
    {
        int damage = Game.ComputeIntegerExpression(DamageRoll, GetExpressionProviders(monster)).Value;
        if (MaxDamage.HasValue && damage > MaxDamage.Value)
        {
            damage = MaxDamage.Value;
        }
        return damage;
    }

    protected int? MaxDamage { get; } = null;

    /// <summary>
    /// Returns the roll expression that determines the amount of damage the arrow projectile inflicts.  This expression is parse
    /// to generate the DamageDiceRoll.
    /// </summary>
    protected string DamageRollExpression { get; }
    public bool InverseRadius { get; }
    protected string RadiusExpressionText { get; }
    protected Expression RadiusExpression { get; private set; }

    /// <summary>
    /// Returns the roll that determines the amount of damage the arrow projectile inflicts.  This dice roll is generated by
    /// parsing the DamageDiceRollExpression property during binding.
    /// </summary>
    protected Expression DamageRoll { get; private set; }

    /// <summary>
    /// Returns the radius of the damage.  Projectiles returns 0, by default.
    /// </summary>
    protected int Radius(Monster monster)
    {
        int radius = Game.ComputeIntegerExpression(RadiusExpression, GetExpressionProviders(monster)).Value;
        if (radius < 0)
        {
            throw new Exception($"Radius for a ProjectileMonsterSpell must be 0 or greater.  Computed radius was {radius} for monster {monster.Name}.  Use the {nameof(InverseRadius)} method for inverse radius.");
        }
        if (InverseRadius)
        {
            radius = -radius;
        }
        radius = radius + monster.Race.ProjectileBonusRadius;
        return radius;
    }

    /// <summary>
    /// Fires the projectile.  This method allows derived classes to override the projectile parameters.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="who"></param>
    /// <param name="rad"></param>
    /// <param name="y"></param>
    /// <param name="x"></param>
    /// <param name="dam"></param>
    /// <param name="projectile"></param>
    /// <param name="flg"></param>
    /// <returns></returns>
    private IsNoticedEnum Project(Monster monster, int rad, int y, int x, int dam, Projectile projectile, bool grid, bool stop, bool item, bool kill)
    {
        return projectile.Fire(monster.GetMonsterIndex(), rad, Game.MapY.IntValue, Game.MapX.IntValue, dam, grid: grid, stop: stop, item: item, kill: kill, jump: false, beam: false, thru: false, hide: false);
    }

    public string? PreExecuteOnPlayerScriptBindingKey { get; }
    public string? PostExecuteOnPlayerScriptBindingKey { get; }
    public IScriptMonster? PreExecuteOnPlayerScript { get; private set; }
    public IScriptMonster? PostExecuteOnPlayerScript { get; private set; }

    public string? PreExecuteOnMonsterScriptBindingKey { get; }
    public string? PostExecuteOnMonsterScriptBindingKey { get; }
    public IScriptMonsterMonster? PreExecuteOnMonsterScript { get; private set; }
    public IScriptMonsterMonster? PostExecuteOnMonsterScript { get; private set; }
    public sealed override void ExecuteOnPlayer(Monster monster)
    {
        if (PreExecuteOnPlayerScript is not null)
        {
            PreExecuteOnPlayerScript.ExecuteScriptMonster(monster);
        }
        int damage = Damage(monster);
        int radius = Radius(monster);
        Project(monster, radius, Game.MapY.IntValue, Game.MapX.IntValue, damage, Projectile, grid: GridProjectionFlag, stop: StopProjectionFlag, kill: KillProjectionFlag, item: ItemProjectionFlag);
        if (PostExecuteOnPlayerScript is not null)
        {
            PostExecuteOnPlayerScript.ExecuteScriptMonster(monster);
        }
    }

    public sealed override void ExecuteOnMonster(Monster monster, Monster target)
    {
        if (PreExecuteOnMonsterScript is not null)
        {
            PreExecuteOnMonsterScript.ExecuteScriptMonsterMonster(monster, target);
        }
        int damage = Damage(monster);
        int radius = Radius(monster);
        Project(monster, radius, target.MapY, target.MapX, damage, Projectile, grid: GridProjectionFlag, stop: StopProjectionFlag, kill: KillProjectionFlag, item: ItemProjectionFlag);
        if (PostExecuteOnMonsterScript is not null)
        {
            PostExecuteOnMonsterScript.ExecuteScriptMonsterMonster(monster, target);
        }
    }
}


