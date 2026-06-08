// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class SummonMonsterSpell : MonsterSpell
{
    public SummonMonsterSpell(Game game, SummonMonsterSpellGameConfiguration gameConfiguration) : base(game)
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
        MaximumSummonCountExpressionText = gameConfiguration.MaximumSummonCountExpressionText;
        MonsterSelectorBindingKey = gameConfiguration.MonsterSelectorBindingKey;
        FriendlyMonsterSelectorBindingKey = gameConfiguration.FriendlyMonsterSelectorBindingKey;
        SummonLevel = gameConfiguration.SummonLevel;
        BlindNonZeroSummonedMessage = gameConfiguration.BlindNonZeroSummonedMessage;
    }
    public override string ToJson()
    {
        SummonMonsterSpellGameConfiguration definition = new()
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
            MaximumSummonCountExpressionText = MaximumSummonCountExpressionText,
            MonsterSelectorBindingKey = MonsterSelectorBindingKey,
            FriendlyMonsterSelectorBindingKey = FriendlyMonsterSelectorBindingKey,
            SummonLevel = SummonLevel,
            BlindNonZeroSummonedMessage = BlindNonZeroSummonedMessage,
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    public override void Bind(RestoreGameState? restoreGameState)
    {
        base.Bind(restoreGameState);
        MonsterSelector = Game.SingletonRepository.GetNullable<IMonsterSelector>(MonsterSelectorBindingKey);
        FriendlyMonsterSelector = Game.SingletonRepository.GetNullable<IMonsterSelector>(FriendlyMonsterSelectorBindingKey);
        MaximumSummonCountExpression = Game.ParseNumericExpression(MaximumSummonCountExpressionText);
    }

    public override string Key { get; }
    public override (string, string) KnowledgeAction { get; }
    public override bool IsInnate { get; }
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

    /// <summary>
    /// Returns true because all summoning magic spells require intelligence.
    /// </summary>
    public override bool IsIntelligent { get; } = false;

    /// <summary>
    /// Returns true for all summoning magic spells.
    /// </summary>
    public override bool SummonsHelp { get; } = false;

    /// <summary>
    /// Returns the maximum number of monsters that will be summoned.  Returns 6, by default.
    /// </summary>
    protected string MaximumSummonCountExpressionText { get; } = "6";
    public Expression MaximumSummonCountExpression { get; private set; }

    /// <summary>
    /// Returns a monster selector key that is used to specify which type of monster to be summoned; or null, for any monster.  Returns null, by default.
    /// </summary>
    protected string? MonsterSelectorBindingKey { get; } = null;

    /// <summary>
    /// Returns a monster filter that is used to specify which type of monster to be summoned or null, for any monster.
    /// </summary>
    protected IMonsterSelector? MonsterSelector { get; private set; }

    /// <summary>
    /// Returns a monster selector key that is used to specify which type of monster to be summoned when a friendly monster is attacking
    /// another monster, or null for any monster.  Returns the monster selector key, by default.
    /// </summary>
    protected string? FriendlyMonsterSelectorBindingKey { get; } = null;

    /// <summary>
    /// Returns a monster selector that is used to specify which type of monster to be summoned when a friendly monster is attacking
    /// another monster, or null for any monster.  This property is bound using the <see cref="FriendlyMonsterSelectorBindingKey"/> property during the bind phase.
    /// </summary>
    /// <param name="monster"></param>
    /// <returns></returns>
    protected IMonsterSelector? FriendlyMonsterSelector { get; private set; }

    /// <summary>
    /// Returns the level of the monster that is summoned; or null, for a level that is the same as the monster that is doing the summoning.
    /// </summary>
    protected int? SummonLevel { get; } = null;

    public override void ExecuteOnPlayer(Monster monster)
    {
        bool playerIsBlind = Game.BlindnessTimer.Value != 0;
        int count = 0;

        int maximumSummonCount = Game.ComputeIntegerExpression(MaximumSummonCountExpression).Value;
        for (int k = 0; k < maximumSummonCount; k++)
        {
            int playerX = Game.MapX.IntValue;
            int playerY = Game.MapY.IntValue;
            int summonLevel = SummonLevel.HasValue ? SummonLevel.Value : monster.Race.Level >= 1 ? monster.Race.Level : 1;

            if (Game.SummonSpecific(playerY, playerX, summonLevel, MonsterSelector?.GetMonsterFilter(monster.Race), true, false))
            {
                count++;
            }
        }
        if (playerIsBlind && count != 0)
        {
            Game.MsgPrint("You hear many things appear nearby.");
        }
    }

    /// <summary>
    /// Returns the message to be rendered to the player, when at least one monster has been summoned but the player is blind.  Returns a
    /// message indicating that the player hears many things appear nearby.
    /// </summary>
    protected string BlindNonZeroSummonedMessage { get; } = "You hear many things appear nearby.";

    public override void ExecuteOnMonster(Monster monster, Monster target)
    {
        bool playerIsBlind = Game.BlindnessTimer.Value != 0;
        bool friendly = monster.IsPet;
        int count = 0;

        for (int k = 0; k < 8; k++)
        {
            int summonLevel = SummonLevel.HasValue ? SummonLevel.Value : monster.Race.Level >= 1 ? monster.Race.Level : 1;
            if (friendly)
            {
                IMonsterSelector? friendlyMonsterSelector = FriendlyMonsterSelector;
                if (friendlyMonsterSelector is null)
                {
                    friendlyMonsterSelector = MonsterSelector;
                }
                MonsterRaceFilter? friendlyMonsterFilter = friendlyMonsterSelector?.GetMonsterFilter(monster.Race);
                if (Game.SummonSpecific(target.MapY, target.MapX, summonLevel, friendlyMonsterFilter, true, true))
                {
                    count++;
                }
            }
            else
            {
                MonsterRaceFilter? monsterFilter = MonsterSelector?.GetMonsterFilter(monster.Race);
                if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, summonLevel, monsterFilter, true, false))
                {
                    count++;
                }
            }
        }
        if (playerIsBlind && count != 0)
        {
            Game.MsgPrint(BlindNonZeroSummonedMessage);
        }
    }
}
