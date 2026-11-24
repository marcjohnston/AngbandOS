using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class CauseWoundsMonsterSpellGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("(string CollapsableActionVerb, string UniqueDescription)",
        Title = "Knowledge Action",
        Description = "The action information displayed when the spell is described in the player's knowledge.")]
    [ConfigurationTupleItem(
        "CollapsableActionVerb",
        Title = "Collapsable Action Verb")]
    [ConfigurationTupleItem(
        "UniqueDescription",
        Title = "Unique Description")]
    public virtual (string CollapsableActionVerb, string UniqueDescription) KnowledgeAction { get; set; }

    [ConfigurationProperty("bool",
        Title = "Is Innate",
        Description = "Determines whether the spell is an innate ability.")]
    public virtual bool IsInnate { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Intelligent",
        Description = "Determines whether the spell is an intelligent spell.")]
    public virtual bool IsIntelligent { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Acid",
        Description = "Determines whether the spell uses acid against its foe.")]
    public virtual bool UsesAcid { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Lightning",
        Description = "Determines whether the spell uses lightning against its foe.")]
    public virtual bool UsesLightning { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Fire",
        Description = "Determines whether the spell uses fire against its foe.")]
    public virtual bool UsesFire { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Cold",
        Description = "Determines whether the spell uses cold against its foe.")]
    public virtual bool UsesCold { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Poison",
        Description = "Determines whether the spell uses poison against its foe.")]
    public virtual bool UsesPoison { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Radiation",
        Description = "Determines whether the spell uses radiation against its foe.")]
    public virtual bool UsesRadiation { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Nether",
        Description = "Determines whether the spell uses nether against its foe.")]
    public virtual bool UsesNether { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Light",
        Description = "Determines whether the spell uses light against its foe.")]
    public virtual bool UsesLight { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Darkness",
        Description = "Determines whether the spell uses darkness against its foe.")]
    public virtual bool UsesDarkness { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Fear",
        Description = "Determines whether the spell uses fear against its foe.")]
    public virtual bool UsesFear { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Confusion",
        Description = "Determines whether the spell uses confusion against its foe.")]
    public virtual bool UsesConfusion { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Breathe",
        Description = "Determines whether the spell uses a breathe attack against its foe.")]
    public virtual bool UsesBreathe { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Chaos",
        Description = "Determines whether the spell uses chaos against its foe.")]
    public virtual bool UsesChaos { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Disenchantment",
        Description = "Determines whether the spell uses disenchantment against its foe.")]
    public virtual bool UsesDisenchantment { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Blindness",
        Description = "Determines whether the spell uses blindness against its foe.")]
    public virtual bool UsesBlindness { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Nexus",
        Description = "Determines whether the spell uses nexus against its foe.")]
    public virtual bool UsesNexus { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Sound",
        Description = "Determines whether the spell uses sound against its foe.")]
    public virtual bool UsesSound { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Uses Shards",
        Description = "Determines whether the spell uses shards against its foe.")]
    public virtual bool UsesShards { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Can Be Reflected",
        Description = "Determines whether the spell can be reflected back from its foe.")]
    public virtual bool CanBeReflected { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Restricts Free Action",
        Description = "Determines whether the spell restricts free action against its foe.")]
    public virtual bool RestrictsFreeAction { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Drains Mana",
        Description = "Determines whether the spell drains mana from its foe.")]
    public virtual bool DrainsMana { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Summons Help",
        Description = "Determines whether the spell summons help against its foe.")]
    public virtual bool SummonsHelp { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Provides Escape",
        Description = "Determines whether the spell provides escape from its foe.")]
    public virtual bool ProvidesEscape { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Heals",
        Description = "Determines whether the spell heals.")]
    public virtual bool Heals { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Attack",
        Description = "Determines whether the spell can attack its foe.")]
    public virtual bool IsAttack { get; set; } = true;

    [ConfigurationProperty("bool",
        Title = "Is Tactical",
        Description = "Determines whether the spell is tactical.")]
    public virtual bool IsTactical { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Hastens",
        Description = "Determines whether the spell hastens itself.")]
    public virtual bool Hastens { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Annoys",
        Description = "Determines whether the spell annoys its foe.")]
    public virtual bool Annoys { get; set; } = true;

    [ConfigurationProperty("string?",
        Title = "Vs Player Blind Message",
        Description = "The message rendered when the spell targets the player while the player is blind.")]
    public virtual string? VsPlayerBlindMessage { get; set; } = "You hear someone mumble.";

    [ConfigurationProperty("string?",
        Title = "Vs Player Action Message",
        Description = "The message rendered when the spell targets a visible player who is not blind.")]
    public virtual string? VsPlayerActionMessage { get; set; } = "{0} points at you and curses.";

    [ConfigurationProperty("string?",
        Title = "Vs Player Action Message On Invisible Monster",
        Description = "The message rendered when the spell targets the player while the monster is not visible.")]
    public virtual string? VsPlayerActionMessageOnInvisibleMonster { get; set; }

    [ConfigurationProperty("string?",
        Title = "Vs Monster Unseen Message",
        Description = "The message rendered when the spell targets another monster while the player is blind.")]
    public virtual string? VsMonsterUnseenMessage { get; set; } = null;

    [ConfigurationProperty("string?",
        Title = "Vs Monster Seen Message",
        Description = "The message rendered when a monster attacks another monster and the player can see the interaction.")]
    public virtual string? VsMonsterSeenMessage { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "Smart Learn Spell Resistant Detection Keys",
        Description = "The spell resistant detection keys learned when the player experiences or sees the spell.")]
    public virtual string[]? SmartLearnSpellResistantDetectionKeys { get; set; } = null;

    [ConfigurationProperty("bool",
        Title = "Wakes Sleeping Monsters",
        Description = "Determines whether attacking a sleeping monster wakes it.")]
    public virtual bool WakesSleepingMonsters { get; set; } = true;

    [ConfigurationProperty("string",
        Title = "Damage Roll Expression",
        Description = "The roll expression used to determine the amount of damage inflicted by the projectile.")]
    public virtual string DamageRollExpression { get; set; }

    [ConfigurationProperty("int",
        Title = "Curse Equipment Chance",
        Description = "The chance that an item of equipment worn by the player will be cursed.")]
    public virtual int CurseEquipmentChance { get; set; }

    [ConfigurationProperty("int",
        Title = "Heavy Curse Equipment Chance",
        Description = "The chance that an item of equipment worn by the player will be heavily cursed.")]
    public virtual int HeavyCurseEquipmentChance { get; set; }

    [ConfigurationProperty("string",
        Title = "Timed Bleeding Expression Text",
        Description = "The expression determining the additional amount of time the player will bleed.")]
    public virtual string TimedBleedingExpressionText { get; set; } = "0";
}
