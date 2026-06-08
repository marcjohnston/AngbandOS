// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class CauseWoundsMonsterSpell : MonsterSpell
{
    public CauseWoundsMonsterSpell(Game game, CauseWoundsMonsterSpellGameConfiguration gameConfiguration) : base(game)
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
        DamageRollExpression = gameConfiguration.DamageRollExpression;
        CurseEquipmentChance = gameConfiguration.CurseEquipmentChance;
        HeavyCurseEquipmentChance = gameConfiguration.HeavyCurseEquipmentChance;
        TimedBleedingExpressionText = gameConfiguration.TimedBleedingExpressionText;
    }
    public override string Key { get; }

    public override string ToJson()
    {
        CauseWoundsMonsterSpellGameConfiguration definition = new()
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
            DamageRollExpression = DamageRollExpression,
            CurseEquipmentChance = CurseEquipmentChance,
            HeavyCurseEquipmentChance = HeavyCurseEquipmentChance,
            TimedBleedingExpressionText = TimedBleedingExpressionText,
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }
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
    public override bool WakesSleepingMonsters { get; }

    public override void Bind(RestoreGameState? restoreGameState)
    {
        base.Bind(restoreGameState);
        DamageRoll = Game.ParseNumericExpression(DamageRollExpression);
        TimedBleedingExpression = Game.ParseNumericExpression(TimedBleedingExpressionText);
    }

    public override bool IsAttack { get; }
    public override bool Annoys { get; }

    public override string? VsPlayerBlindMessage { get; }

    public override string? VsPlayerActionMessage { get; }

    /// <summary>
    /// Returns the roll expression that determines the amount of damage the arrow projectile inflicts.  This expression is parse
    /// to generate the DamageDiceRoll.
    /// </summary>
    protected string DamageRollExpression { get; }

    /// <summary>
    /// Returns the roll that determines the amount of damage the arrow projectile inflicts.  This dice roll is generated by
    /// parsing the DamageDiceRollExpression property during binding.
    /// </summary>
    protected Expression DamageRoll { get; private set; }

    /// <summary>
    /// Returns the chance that an item of equipment that the player is wearing will be cursed.
    /// </summary>
    protected int CurseEquipmentChance { get; }

    /// <summary>
    /// Returns the chance that an item of equipment that the player is wearing will be heavily cursed.
    /// </summary>
    protected int HeavyCurseEquipmentChance { get; }

    public string TimedBleedingExpressionText = "0";
    /// <summary>
    /// Returns an additional amount of time the player will bleed.  Returns 0, by default.
    /// </summary>
    protected Expression TimedBleedingExpression { get; private set; }
    public override void ExecuteOnPlayer(Monster monster)
    {
        if (Game.RandomLessThan(100) < Game.SkillSavingThrow)
        {
            Game.MsgPrint("You resist the effects!");
        }
        else
        {
            string monsterDescription = monster.IndefiniteVisibleName;

            Game.CurseEquipment(CurseEquipmentChance, HeavyCurseEquipmentChance);
            int damage = Game.ComputeIntegerExpression(DamageRoll).Value;
            Game.TakeHit(damage, monsterDescription);

            int timedBleeding = Game.ComputeIntegerExpression(TimedBleedingExpression).Value;
            if (timedBleeding > 0)
            {
                Game.BleedingTimer.AddTimer(timedBleeding);
            }
        }
    }

    public override void ExecuteOnMonster(Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        string targetName = target.Name;
        bool blind = Game.BlindnessTimer.Value != 0;
        bool seeTarget = !blind && target.IsVisible;
        MonsterRace targetRace = target.Race;

        if (targetRace.Level > base.Game.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
        {
            if (seeTarget)
            {
                Game.MsgPrint($"{targetName} resists!");
            }
        }
        else
        {
            int damage = Game.ComputeIntegerExpression(DamageRoll).Value;
            target.TakeDamageFromAnotherMonster(damage, out _, " is destroyed.");
        }
    }
}