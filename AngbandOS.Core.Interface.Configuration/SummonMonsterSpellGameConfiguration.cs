using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class SummonMonsterSpellGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationTupleItem(
        "Item1",
        Title = "Item 1")]
    [ConfigurationTupleItem(
        "Item2",
        Title = "Item 2")]
    [ConfigurationProperty(
        Title = "Knowledge Action",
        Summary = "Specifies the knowledge action associated with the summon monster spell.",
        DataType = "(string, string)")]
    public virtual (string, string) KnowledgeAction { get; set; }

    [ConfigurationProperty(
        Title = "Is Innate",
        Summary = "Determines whether the spell is an innate ability.",
        DataType = "bool")]
    public virtual bool IsInnate { get; set; } = false;

    [ConfigurationProperty(
        Title = "Is Intelligent",
        Summary = "Determines whether the spell is an intelligent spell.",
        DataType = "bool")]
    public virtual bool IsIntelligent { get; set; } = true;

    [ConfigurationProperty(
        Title = "Uses Acid",
        Summary = "Determines whether the spell uses acid against its foe.",
        DataType = "bool")]
    public virtual bool UsesAcid { get; set; } = false;

    [ConfigurationProperty(
        Title = "Uses Lightning",
        Summary = "Determines whether the spell uses lightning against its foe.",
        DataType = "bool")]
    public virtual bool UsesLightning { get; set; } = false;

    [ConfigurationProperty(
        Title = "Uses Fire",
        Summary = "Determines whether the spell uses fire against its foe.",
        DataType = "bool")]
    public virtual bool UsesFire { get; set; } = false;

    [ConfigurationProperty(
        Title = "Uses Cold",
        Summary = "Determines whether the spell uses cold against its foe.",
        DataType = "bool")]
    public virtual bool UsesCold { get; set; } = false;

    [ConfigurationProperty(
        Title = "Uses Poison",
        Summary = "Determines whether the spell uses poison against its foe.",
        DataType = "bool")]
    public virtual bool UsesPoison { get; set; } = false;

    [ConfigurationProperty(
        Title = "Uses Radiation",
        Summary = "Determines whether the spell uses radiation against its foe.",
        DataType = "bool")]
    public virtual bool UsesRadiation { get; set; } = false;

    [ConfigurationProperty(
        Title = "Uses Nether",
        Summary = "Determines whether the spell uses nether against its foe.",
        DataType = "bool")]
    public virtual bool UsesNether { get; set; } = false;

    [ConfigurationProperty(
        Title = "Uses Light",
        Summary = "Determines whether the spell uses light against its foe.",
        DataType = "bool")]
    public virtual bool UsesLight { get; set; } = false;

    [ConfigurationProperty(
        Title = "Uses Darkness",
        Summary = "Determines whether the spell uses darkness against its foe.",
        DataType = "bool")]
    public virtual bool UsesDarkness { get; set; } = false;

    [ConfigurationProperty(
        Title = "Uses Fear",
        Summary = "Determines whether the spell uses fear against its foe.",
        DataType = "bool")]
    public virtual bool UsesFear { get; set; } = false;

    [ConfigurationProperty(
        Title = "Uses Confusion",
        Summary = "Determines whether the spell uses confusion against its foe.",
        DataType = "bool")]
    public virtual bool UsesConfusion { get; set; } = false;

    [ConfigurationProperty(
        Title = "Uses Breathe",
        Summary = "Determines whether the spell uses a breath attack against its foe.",
        DataType = "bool")]
    public virtual bool UsesBreathe { get; set; } = false;

    [ConfigurationProperty(
        Title = "Uses Chaos",
        Summary = "Determines whether the spell uses chaos against its foe.",
        DataType = "bool")]
    public virtual bool UsesChaos { get; set; } = false;

    [ConfigurationProperty(
        Title = "Uses Disenchantment",
        Summary = "Determines whether the spell uses disenchantment against its foe.",
        DataType = "bool")]
    public virtual bool UsesDisenchantment { get; set; } = false;

    [ConfigurationProperty(
        Title = "Uses Blindness",
        Summary = "Determines whether the spell uses blindness against its foe.",
        DataType = "bool")]
    public virtual bool UsesBlindness { get; set; } = false;

    [ConfigurationProperty(
        Title = "Uses Nexus",
        Summary = "Determines whether the spell uses nexus against its foe.",
        DataType = "bool")]
    public virtual bool UsesNexus { get; set; } = false;

    [ConfigurationProperty(
        Title = "Uses Sound",
        Summary = "Determines whether the spell uses sound against its foe.",
        DataType = "bool")]
    public virtual bool UsesSound { get; set; } = false;

    [ConfigurationProperty(
        Title = "Uses Shards",
        Summary = "Determines whether the spell uses shards against its foe.",
        DataType = "bool")]
    public virtual bool UsesShards { get; set; } = false;

    [ConfigurationProperty(
        Title = "Can Be Reflected",
        Summary = "Determines whether the spell can be reflected back from its foe.",
        DataType = "bool")]
    public virtual bool CanBeReflected { get; set; } = false;

    [ConfigurationProperty(
        Title = "Restricts Free Action",
        Summary = "Determines whether the spell restricts free action against its foe.",
        DataType = "bool")]
    public virtual bool RestrictsFreeAction { get; set; } = false;

    [ConfigurationProperty(
        Title = "Drains Mana",
        Summary = "Determines whether the spell drains mana from its foe.",
        DataType = "bool")]
    public virtual bool DrainsMana { get; set; } = false;

    [ConfigurationProperty(
        Title = "Summons Help",
        Summary = "Determines whether the spell summons help against its foe.",
        DataType = "bool")]
    public virtual bool SummonsHelp { get; set; } = true;

    [ConfigurationProperty(
        Title = "Provides Escape",
        Summary = "Determines whether the spell provides an escape from its foe.",
        DataType = "bool")]
    public virtual bool ProvidesEscape { get; set; } = false;

    [ConfigurationProperty(
        Title = "Heals",
        Summary = "Determines whether the spell heals.",
        DataType = "bool")]
    public virtual bool Heals { get; set; } = false;

    [ConfigurationProperty(
        Title = "Is Attack",
        Summary = "Determines whether the spell can attack its foe.",
        DataType = "bool")]
    public virtual bool IsAttack { get; set; } = false;

    [ConfigurationProperty(
        Title = "Is Tactical",
        Summary = "Determines whether the spell is tactical against its foe.",
        DataType = "bool")]
    public virtual bool IsTactical { get; set; } = false;

    [ConfigurationProperty(
        Title = "Hastens",
        Summary = "Determines whether the spell hastens itself.",
        DataType = "bool")]
    public virtual bool Hastens { get; set; } = false;

    [ConfigurationProperty(
        Title = "Annoys",
        Summary = "Determines whether the spell annoys its foe.",
        DataType = "bool")]
    public virtual bool Annoys { get; set; } = false;

    [ConfigurationProperty(
        Title = "Versus Player Blind Message",
        Summary = "Specifies the message rendered when the spell is used against a blind player.",
        DataType = "string?")]
    public virtual string? VsPlayerBlindMessage { get; set; } = "You hear someone mumble.";

    [ConfigurationProperty(
        Title = "Versus Player Action Message",
        Summary = "Specifies the message rendered when the spell targets a visible player who is not blind.",
        DataType = "string?")]
    public virtual string? VsPlayerActionMessage { get; set; } = null;

    [ConfigurationProperty(
        Title = "Versus Player Action Message On Invisible Monster",
        Summary = "Specifies the message rendered when the spell targets a player while the monster is not visible.",
        DataType = "string?")]
    public virtual string? VsPlayerActionMessageOnInvisibleMonster { get; set; }

    [ConfigurationProperty(
        Title = "Versus Monster Unseen Message",
        Summary = "Specifies the message rendered when the spell is used against another monster while the player is blind.",
        DataType = "string?")]
    public virtual string? VsMonsterUnseenMessage { get; set; } = null;

    [ConfigurationProperty(
        Title = "Versus Monster Seen Message",
        Summary = "Specifies the message rendered when a monster attacks another monster and the player sees either monster.",
        DataType = "string?")]
    public virtual string? VsMonsterSeenMessage { get; set; } = null;

    [ConfigurationProperty(
        Title = "Smart Learn Spell Resistant Detection Keys",
        Summary = "Specifies the spell-resistant detection characteristics learned when the player experiences or sees the spell.",
        DataType = "string[]?")]
    public virtual string[]? SmartLearnSpellResistantDetectionKeys { get; set; } = null;

    [ConfigurationProperty(
        Title = "Wakes Sleeping Monsters",
        Summary = "Determines whether an attack on a sleeping monster wakes it.",
        DataType = "bool")]
    public virtual bool WakesSleepingMonsters { get; set; } = true;

    [ConfigurationProperty(
        Title = "Maximum Summon Count Expression Text",
        Summary = "Specifies the expression that determines the maximum number of monsters summoned.",
        DataType = "string")]
    public virtual string MaximumSummonCountExpressionText { get; set; } = "6";

    [ConfigurationProperty(
        Title = "Monster Selector Binding Key",
        Summary = "Specifies the monster selector binding key used to determine which type of monster is summoned. When null, any monster may be summoned.",
        DataType = "string?")]
    public virtual string? MonsterSelectorBindingKey { get; set; } = null;

    [ConfigurationProperty(
        Title = "Friendly Monster Selector Binding Key",
        Summary = "Specifies the monster selector binding key used when a friendly monster attacks another monster. When null, any monster may be summoned.",
        DataType = "string?")]
    public virtual string? FriendlyMonsterSelectorBindingKey { get; set; } = null;

    [ConfigurationProperty(
        Title = "Summon Level",
        Summary = "Specifies the level of the summoned monster. When null, the summoned monster uses the level of the summoning monster.",
        DataType = "int?")]
    public virtual int? SummonLevel { get; set; } = null;

    [ConfigurationProperty(
        Title = "Blind Non-Zero Summoned Message",
        Summary = "Specifies the message rendered when at least one monster is summoned while the player is blind.",
        DataType = "string")]
    public virtual string BlindNonZeroSummonedMessage { get; set; } = "You hear many things appear nearby.";
}
