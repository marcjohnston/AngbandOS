using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class CauseWoundsMonsterSpellGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationPropertyAttribute(
        Title = "Knowledge Action",
        Summary = "The action information displayed when the spell is described in the player's knowledge.",
        DataType = "(string, string)")]
    [ConfigurationTupleItemAttribute(
        "CollapsableActionVerb",
        Title = "Collapsable Action Verb")]
    [ConfigurationTupleItemAttribute(
        "UniqueDescription",
        Title = "Unique Description")]
    public virtual (string CollapsableActionVerb, string UniqueDescription) KnowledgeAction { get; set; }

    [ConfigurationPropertyAttribute(
        Title = "Is Innate",
        Summary = "Determines whether the spell is an innate ability.",
        DataType = "bool")]
    public virtual bool IsInnate { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Is Intelligent",
        Summary = "Determines whether the spell is an intelligent spell.",
        DataType = "bool")]
    public virtual bool IsIntelligent { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Acid",
        Summary = "Determines whether the spell uses acid against its foe.",
        DataType = "bool")]
    public virtual bool UsesAcid { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Lightning",
        Summary = "Determines whether the spell uses lightning against its foe.",
        DataType = "bool")]
    public virtual bool UsesLightning { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Fire",
        Summary = "Determines whether the spell uses fire against its foe.",
        DataType = "bool")]
    public virtual bool UsesFire { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Cold",
        Summary = "Determines whether the spell uses cold against its foe.",
        DataType = "bool")]
    public virtual bool UsesCold { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Poison",
        Summary = "Determines whether the spell uses poison against its foe.",
        DataType = "bool")]
    public virtual bool UsesPoison { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Radiation",
        Summary = "Determines whether the spell uses radiation against its foe.",
        DataType = "bool")]
    public virtual bool UsesRadiation { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Nether",
        Summary = "Determines whether the spell uses nether against its foe.",
        DataType = "bool")]
    public virtual bool UsesNether { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Light",
        Summary = "Determines whether the spell uses light against its foe.",
        DataType = "bool")]
    public virtual bool UsesLight { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Darkness",
        Summary = "Determines whether the spell uses darkness against its foe.",
        DataType = "bool")]
    public virtual bool UsesDarkness { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Fear",
        Summary = "Determines whether the spell uses fear against its foe.",
        DataType = "bool")]
    public virtual bool UsesFear { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Confusion",
        Summary = "Determines whether the spell uses confusion against its foe.",
        DataType = "bool")]
    public virtual bool UsesConfusion { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Breathe",
        Summary = "Determines whether the spell uses a breathe attack against its foe.",
        DataType = "bool")]
    public virtual bool UsesBreathe { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Chaos",
        Summary = "Determines whether the spell uses chaos against its foe.",
        DataType = "bool")]
    public virtual bool UsesChaos { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Disenchantment",
        Summary = "Determines whether the spell uses disenchantment against its foe.",
        DataType = "bool")]
    public virtual bool UsesDisenchantment { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Blindness",
        Summary = "Determines whether the spell uses blindness against its foe.",
        DataType = "bool")]
    public virtual bool UsesBlindness { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Nexus",
        Summary = "Determines whether the spell uses nexus against its foe.",
        DataType = "bool")]
    public virtual bool UsesNexus { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Sound",
        Summary = "Determines whether the spell uses sound against its foe.",
        DataType = "bool")]
    public virtual bool UsesSound { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Uses Shards",
        Summary = "Determines whether the spell uses shards against its foe.",
        DataType = "bool")]
    public virtual bool UsesShards { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Can Be Reflected",
        Summary = "Determines whether the spell can be reflected back from its foe.",
        DataType = "bool")]
    public virtual bool CanBeReflected { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Restricts Free Action",
        Summary = "Determines whether the spell restricts free action against its foe.",
        DataType = "bool")]
    public virtual bool RestrictsFreeAction { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Drains Mana",
        Summary = "Determines whether the spell drains mana from its foe.",
        DataType = "bool")]
    public virtual bool DrainsMana { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Summons Help",
        Summary = "Determines whether the spell summons help against its foe.",
        DataType = "bool")]
    public virtual bool SummonsHelp { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Provides Escape",
        Summary = "Determines whether the spell provides escape from its foe.",
        DataType = "bool")]
    public virtual bool ProvidesEscape { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Heals",
        Summary = "Determines whether the spell heals.",
        DataType = "bool")]
    public virtual bool Heals { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Is Attack",
        Summary = "Determines whether the spell can attack its foe.",
        DataType = "bool")]
    public virtual bool IsAttack { get; set; } = true;

    [ConfigurationPropertyAttribute(
        Title = "Is Tactical",
        Summary = "Determines whether the spell is tactical.",
        DataType = "bool")]
    public virtual bool IsTactical { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Hastens",
        Summary = "Determines whether the spell hastens itself.",
        DataType = "bool")]
    public virtual bool Hastens { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Annoys",
        Summary = "Determines whether the spell annoys its foe.",
        DataType = "bool")]
    public virtual bool Annoys { get; set; } = true;

    [ConfigurationPropertyAttribute(
        Title = "Vs Player Blind Message",
        Summary = "The message rendered when the spell targets the player while the player is blind.",
        DataType = "string?")]
    public virtual string? VsPlayerBlindMessage { get; set; } = "You hear someone mumble.";

    [ConfigurationPropertyAttribute(
        Title = "Vs Player Action Message",
        Summary = "The message rendered when the spell targets a visible player who is not blind.",
        DataType = "string?")]
    public virtual string? VsPlayerActionMessage { get; set; } = "{0} points at you and curses.";

    [ConfigurationPropertyAttribute(
        Title = "Vs Player Action Message On Invisible Monster",
        Summary = "The message rendered when the spell targets the player while the monster is not visible.",
        DataType = "string?")]
    public virtual string? VsPlayerActionMessageOnInvisibleMonster { get; set; }

    [ConfigurationPropertyAttribute(
        Title = "Vs Monster Unseen Message",
        Summary = "The message rendered when the spell targets another monster while the player is blind.",
        DataType = "string?")]
    public virtual string? VsMonsterUnseenMessage { get; set; } = null;

    [ConfigurationPropertyAttribute(
        Title = "Vs Monster Seen Message",
        Summary = "The message rendered when a monster attacks another monster and the player can see the interaction.",
        DataType = "string?")]
    public virtual string? VsMonsterSeenMessage { get; set; } = null;

    [ConfigurationPropertyAttribute(
        Title = "Smart Learn Spell Resistant Detection Keys",
        Summary = "The spell resistant detection keys learned when the player experiences or sees the spell.",
        DataType = "string[]?")]
    public virtual string[]? SmartLearnSpellResistantDetectionKeys { get; set; } = null;

    [ConfigurationPropertyAttribute(
        Title = "Wakes Sleeping Monsters",
        Summary = "Determines whether attacking a sleeping monster wakes it.",
        DataType = "bool")]
    public virtual bool WakesSleepingMonsters { get; set; } = true;

    [ConfigurationPropertyAttribute(
        Title = "Damage Roll Expression",
        Summary = "The roll expression used to determine the amount of damage inflicted by the projectile.",
        DataType = "string")]
    public virtual string DamageRollExpression { get; set; }

    [ConfigurationPropertyAttribute(
        Title = "Curse Equipment Chance",
        Summary = "The chance that an item of equipment worn by the player will be cursed.",
        DataType = "int")]
    public virtual int CurseEquipmentChance { get; set; }

    [ConfigurationPropertyAttribute(
        Title = "Heavy Curse Equipment Chance",
        Summary = "The chance that an item of equipment worn by the player will be heavily cursed.",
        DataType = "int")]
    public virtual int HeavyCurseEquipmentChance { get; set; }

    [ConfigurationPropertyAttribute(
        Title = "Timed Bleeding Expression Text",
        Summary = "The expression determining the additional amount of time the player will bleed.",
        DataType = "string")]
    public virtual string TimedBleedingExpressionText { get; set; } = "0";
}
