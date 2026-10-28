// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal sealed class ScriptMonsterSpell : MonsterSpell
{
    public ScriptMonsterSpell(Game game, ScriptMonsterSpellGameConfiguration gameConfiguration) : base(game)
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
        KnowledgeAction = gameConfiguration.KnowledgeAction;
        ExecuteOnPlayerScriptBindingKey = gameConfiguration.ExecuteOnPlayerScriptBindingKey;
        ExecuteOnMonsterScriptBindingKey = gameConfiguration.ExecuteOnMonsterScriptBindingKey;
    }
    public override string ToJson()
    {
        ScriptMonsterSpellGameConfiguration definition = new()
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
            KnowledgeAction = KnowledgeAction,
            ExecuteOnPlayerScriptBindingKey = ExecuteOnPlayerScriptBindingKey,
            ExecuteOnMonsterScriptBindingKey = ExecuteOnMonsterScriptBindingKey,
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    public override string Key { get; }
    public override bool IsAttack { get; }
    public override bool Annoys { get; }

    public override string? VsPlayerBlindMessage { get; }
    public override bool WakesSleepingMonsters { get; }

    public override string? VsPlayerActionMessage { get; }

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
    public override bool IsTactical { get; }
    public override bool Hastens { get; }
    public override string? VsPlayerActionMessageOnInvisibleMonster { get; }
    public override string? VsMonsterUnseenMessage { get; }
    public override string? VsMonsterSeenMessage { get; }
    protected override string[]? SmartLearnSpellResistantDetectionKeys { get; }

    /// <summary>
    /// Returns the binding key for the script to execute when this spell is executed on the player. If null, no script will be executed.
    /// </summary>
    public string? ExecuteOnPlayerScriptBindingKey { get; } = null;

    /// <summary>
    /// Returns the script to execute when this spell is executed on the player. If null, no script will be executed.  This property is populated during the Bind phase.
    /// </summary>
    public IScriptMonster? ExecuteOnPlayerScript { get; private set; }

    /// <summary>
    /// Returns the binding key for the script to execute when this spell is executed on a monster. If null, no script will be executed.
    /// </summary>
    public string? ExecuteOnMonsterScriptBindingKey { get; } = null;

    /// <summary>
    /// Returns the script to execute when this spell is executed on a monster. If null, no script will be executed.  This property is populated during the Bind phase.
    /// </summary>
    public IScriptMonsterMonster? ExecuteOnMonsterScript { get; private set; }

    public override void Bind(RestoreGameState? restoreGameState)
    {
        base.Bind(restoreGameState);
        ExecuteOnPlayerScript = Game.SingletonRepository.GetNullable<IScriptMonster>(ExecuteOnPlayerScriptBindingKey);
        ExecuteOnMonsterScript = Game.SingletonRepository.GetNullable<IScriptMonsterMonster>(ExecuteOnMonsterScriptBindingKey);
    }

    public sealed override void ExecuteOnPlayer(Monster monster)
    {
        if (ExecuteOnPlayerScript is not null)
        {
            ExecuteOnPlayerScript.ExecuteScriptMonster(monster);
        }
    }

    public sealed override void ExecuteOnMonster(Monster monster, Monster target)
    {
        if (ExecuteOnMonsterScript is not null)
        {
            ExecuteOnMonsterScript.ExecuteScriptMonsterMonster(monster, target);
        }
    }
}
