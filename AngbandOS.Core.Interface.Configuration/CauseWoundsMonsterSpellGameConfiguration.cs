using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntityAttribute(
    Title = "Cause Wounds Monster Spell",
    EntityNoun = "Cause Wounds Monster Spell")]
public class CauseWoundsMonsterSpellGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
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

    [ConfigurationMetadataAttribute(
        Title = "Is Innate",
        Summary = "Determines whether the spell is an innate ability.",
        DataType = "bool")]
    public virtual bool IsInnate { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Is Intelligent",
        Summary = "Determines whether the spell is an intelligent spell.",
        DataType = "bool")]
    public virtual bool IsIntelligent { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Acid",
        Summary = "Determines whether the spell uses acid against its foe.",
        DataType = "bool")]
    public virtual bool UsesAcid { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Lightning",
        Summary = "Determines whether the spell uses lightning against its foe.",
        DataType = "bool")]
    public virtual bool UsesLightning { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Fire",
        Summary = "Determines whether the spell uses fire against its foe.",
        DataType = "bool")]
    public virtual bool UsesFire { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Cold",
        Summary = "Determines whether the spell uses cold against its foe.",
        DataType = "bool")]
    public virtual bool UsesCold { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Poison",
        Summary = "Determines whether the spell uses poison against its foe.",
        DataType = "bool")]
    public virtual bool UsesPoison { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Radiation",
        Summary = "Determines whether the spell uses radiation against its foe.",
        DataType = "bool")]
    public virtual bool UsesRadiation { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Nether",
        Summary = "Determines whether the spell uses nether against its foe.",
        DataType = "bool")]
    public virtual bool UsesNether { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Light",
        Summary = "Determines whether the spell uses light against its foe.",
        DataType = "bool")]
    public virtual bool UsesLight { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Darkness",
        Summary = "Determines whether the spell uses darkness against its foe.",
        DataType = "bool")]
    public virtual bool UsesDarkness { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Fear",
        Summary = "Determines whether the spell uses fear against its foe.",
        DataType = "bool")]
    public virtual bool UsesFear { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Confusion",
        Summary = "Determines whether the spell uses confusion against its foe.",
        DataType = "bool")]
    public virtual bool UsesConfusion { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Breathe",
        Summary = "Determines whether the spell uses a breathe attack against its foe.",
        DataType = "bool")]
    public virtual bool UsesBreathe { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Chaos",
        Summary = "Determines whether the spell uses chaos against its foe.",
        DataType = "bool")]
    public virtual bool UsesChaos { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Disenchantment",
        Summary = "Determines whether the spell uses disenchantment against its foe.",
        DataType = "bool")]
    public virtual bool UsesDisenchantment { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Blindness",
        Summary = "Determines whether the spell uses blindness against its foe.",
        DataType = "bool")]
    public virtual bool UsesBlindness { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Nexus",
        Summary = "Determines whether the spell uses nexus against its foe.",
        DataType = "bool")]
    public virtual bool UsesNexus { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Sound",
        Summary = "Determines whether the spell uses sound against its foe.",
        DataType = "bool")]
    public virtual bool UsesSound { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Uses Shards",
        Summary = "Determines whether the spell uses shards against its foe.",
        DataType = "bool")]
    public virtual bool UsesShards { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Can Be Reflected",
        Summary = "Determines whether the spell can be reflected back from its foe.",
        DataType = "bool")]
    public virtual bool CanBeReflected { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Restricts Free Action",
        Summary = "Determines whether the spell restricts free action against its foe.",
        DataType = "bool")]
    public virtual bool RestrictsFreeAction { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Drains Mana",
        Summary = "Determines whether the spell drains mana from its foe.",
        DataType = "bool")]
    public virtual bool DrainsMana { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Summons Help",
        Summary = "Determines whether the spell summons help against its foe.",
        DataType = "bool")]
    public virtual bool SummonsHelp { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Provides Escape",
        Summary = "Determines whether the spell provides escape from its foe.",
        DataType = "bool")]
    public virtual bool ProvidesEscape { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Heals",
        Summary = "Determines whether the spell heals.",
        DataType = "bool")]
    public virtual bool Heals { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Is Attack",
        Summary = "Determines whether the spell can attack its foe.",
        DataType = "bool")]
    public virtual bool IsAttack { get; set; } = true;

    [ConfigurationMetadataAttribute(
        Title = "Is Tactical",
        Summary = "Determines whether the spell is tactical.",
        DataType = "bool")]
    public virtual bool IsTactical { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Hastens",
        Summary = "Determines whether the spell hastens itself.",
        DataType = "bool")]
    public virtual bool Hastens { get; set; } = false;

    [ConfigurationMetadataAttribute(
        Title = "Annoys",
        Summary = "Determines whether the spell annoys its foe.",
        DataType = "bool")]
    public virtual bool Annoys { get; set; } = true;

    [ConfigurationMetadataAttribute(
        Title = "Vs Player Blind Message",
        Summary = "The message rendered when the spell targets the player while the player is blind.",
        DataType = "string?")]
    public virtual string? VsPlayerBlindMessage { get; set; } = "You hear someone mumble.";

    [ConfigurationMetadataAttribute(
        Title = "Vs Player Action Message",
        Summary = "The message rendered when the spell targets a visible player who is not blind.",
        DataType = "string?")]
    public virtual string? VsPlayerActionMessage { get; set; } = "{0} points at you and curses.";

    [ConfigurationMetadataAttribute(
        Title = "Vs Player Action Message On Invisible Monster",
        Summary = "The message rendered when the spell targets the player while the monster is not visible.",
        DataType = "string?")]
    public virtual string? VsPlayerActionMessageOnInvisibleMonster { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Vs Monster Unseen Message",
        Summary = "The message rendered when the spell targets another monster while the player is blind.",
        DataType = "string?")]
    public virtual string? VsMonsterUnseenMessage { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Vs Monster Seen Message",
        Summary = "The message rendered when a monster attacks another monster and the player can see the interaction.",
        DataType = "string?")]
    public virtual string? VsMonsterSeenMessage { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Smart Learn Spell Resistant Detection Keys",
        Summary = "The spell resistant detection keys learned when the player experiences or sees the spell.",
        DataType = "string[]?")]
    public virtual string[]? SmartLearnSpellResistantDetectionKeys { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Wakes Sleeping Monsters",
        Summary = "Determines whether attacking a sleeping monster wakes it.",
        DataType = "bool")]
    public virtual bool WakesSleepingMonsters { get; set; } = true;

    [ConfigurationMetadataAttribute(
        Title = "Damage Roll Expression",
        Summary = "The roll expression used to determine the amount of damage inflicted by the projectile.",
        DataType = "string")]
    public virtual string DamageRollExpression { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Curse Equipment Chance",
        Summary = "The chance that an item of equipment worn by the player will be cursed.",
        DataType = "int")]
    public virtual int CurseEquipmentChance { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Heavy Curse Equipment Chance",
        Summary = "The chance that an item of equipment worn by the player will be heavily cursed.",
        DataType = "int")]
    public virtual int HeavyCurseEquipmentChance { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Timed Bleeding Expression Text",
        Summary = "The expression determining the additional amount of time the player will bleed.",
        DataType = "string")]
    public virtual string TimedBleedingExpressionText { get; set; } = "0";
}
