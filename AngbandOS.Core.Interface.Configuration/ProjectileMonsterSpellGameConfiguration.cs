using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ProjectileMonsterSpellGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationTupleItem(
        "Item1",
        Title = "Item 1")]
    [ConfigurationTupleItem(
        "Item2",
        Title = "Item 2")]
    [ConfigurationMetadata(
        Title = "Knowledge Action",
        Summary = "Specifies the knowledge action associated with the projectile monster spell.",
        DataType = "(string, string)")]
    public virtual (string, string) KnowledgeAction { get; set; }

    [ConfigurationMetadata(
        Title = "Is Innate",
        Summary = "Determines whether the spell is an innate ability.",
        DataType = "bool")]
    public virtual bool IsInnate { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Is Intelligent",
        Summary = "Determines whether the spell is an intelligent spell.",
        DataType = "bool")]
    public virtual bool IsIntelligent { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Acid",
        Summary = "Determines whether the spell uses acid against its foe.",
        DataType = "bool")]
    public virtual bool UsesAcid { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Lightning",
        Summary = "Determines whether the spell uses lightning against its foe.",
        DataType = "bool")]
    public virtual bool UsesLightning { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Fire",
        Summary = "Determines whether the spell uses fire against its foe.",
        DataType = "bool")]
    public virtual bool UsesFire { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Cold",
        Summary = "Determines whether the spell uses cold against its foe.",
        DataType = "bool")]
    public virtual bool UsesCold { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Poison",
        Summary = "Determines whether the spell uses poison against its foe.",
        DataType = "bool")]
    public virtual bool UsesPoison { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Radiation",
        Summary = "Determines whether the spell uses radiation against its foe.",
        DataType = "bool")]
    public virtual bool UsesRadiation { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Nether",
        Summary = "Determines whether the spell uses nether against its foe.",
        DataType = "bool")]
    public virtual bool UsesNether { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Light",
        Summary = "Determines whether the spell uses light against its foe.",
        DataType = "bool")]
    public virtual bool UsesLight { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Darkness",
        Summary = "Determines whether the spell uses darkness against its foe.",
        DataType = "bool")]
    public virtual bool UsesDarkness { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Fear",
        Summary = "Determines whether the spell uses fear against its foe.",
        DataType = "bool")]
    public virtual bool UsesFear { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Confusion",
        Summary = "Determines whether the spell uses confusion against its foe.",
        DataType = "bool")]
    public virtual bool UsesConfusion { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Breathe",
        Summary = "Determines whether the spell uses a breath attack against its foe.",
        DataType = "bool")]
    public virtual bool UsesBreathe { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Chaos",
        Summary = "Determines whether the spell uses chaos against its foe.",
        DataType = "bool")]
    public virtual bool UsesChaos { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Disenchantment",
        Summary = "Determines whether the spell uses disenchantment against its foe.",
        DataType = "bool")]
    public virtual bool UsesDisenchantment { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Blindness",
        Summary = "Determines whether the spell uses blindness against its foe.",
        DataType = "bool")]
    public virtual bool UsesBlindness { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Nexus",
        Summary = "Determines whether the spell uses nexus against its foe.",
        DataType = "bool")]
    public virtual bool UsesNexus { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Sound",
        Summary = "Determines whether the spell uses sound against its foe.",
        DataType = "bool")]
    public virtual bool UsesSound { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Uses Shards",
        Summary = "Determines whether the spell uses shards against its foe.",
        DataType = "bool")]
    public virtual bool UsesShards { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Can Be Reflected",
        Summary = "Determines whether the spell can be reflected back from its foe.",
        DataType = "bool")]
    public virtual bool CanBeReflected { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Restricts Free Action",
        Summary = "Determines whether the spell restricts free action against its foe.",
        DataType = "bool")]
    public virtual bool RestrictsFreeAction { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Drains Mana",
        Summary = "Determines whether the spell drains mana from its foe.",
        DataType = "bool")]
    public virtual bool DrainsMana { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Summons Help",
        Summary = "Determines whether the spell summons help against its foe.",
        DataType = "bool")]
    public virtual bool SummonsHelp { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Provides Escape",
        Summary = "Determines whether the spell provides an escape from its foe.",
        DataType = "bool")]
    public virtual bool ProvidesEscape { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Heals",
        Summary = "Determines whether the spell heals.",
        DataType = "bool")]
    public virtual bool Heals { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Is Attack",
        Summary = "Determines whether the spell can attack its foe.",
        DataType = "bool")]
    public virtual bool IsAttack { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Is Tactical",
        Summary = "Determines whether the spell is tactical against its foe.",
        DataType = "bool")]
    public virtual bool IsTactical { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Hastens",
        Summary = "Determines whether the spell hastens itself.",
        DataType = "bool")]
    public virtual bool Hastens { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Annoys",
        Summary = "Determines whether the spell annoys its foe.",
        DataType = "bool")]
    public virtual bool Annoys { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Versus Player Blind Message",
        Summary = "Specifies the message rendered when the spell is used against a blind player.",
        DataType = "string?")]
    public virtual string? VsPlayerBlindMessage { get; set; } = "You hear someone mumble.";

    [ConfigurationMetadata(
        Title = "Versus Player Action Message",
        Summary = "Specifies the message rendered when the spell targets a visible player who is not blind.",
        DataType = "string?")]
    public virtual string? VsPlayerActionMessage { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Versus Player Action Message On Invisible Monster",
        Summary = "Specifies the message rendered when the spell targets a player while the monster is not visible.",
        DataType = "string?")]
    public virtual string? VsPlayerActionMessageOnInvisibleMonster { get; set; }

    [ConfigurationMetadata(
        Title = "Versus Monster Unseen Message",
        Summary = "Specifies the message rendered when the spell is used against another monster while the player is blind.",
        DataType = "string?")]
    public virtual string? VsMonsterUnseenMessage { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Versus Monster Seen Message",
        Summary = "Specifies the message rendered when a monster attacks another monster and the player sees either monster.",
        DataType = "string?")]
    public virtual string? VsMonsterSeenMessage { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Smart Learn Spell Resistant Detection Keys",
        Summary = "Specifies the spell-resistant detection characteristics learned when the player experiences or sees the spell.",
        DataType = "string[]?")]
    public virtual string[]? SmartLearnSpellResistantDetectionKeys { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Wakes Sleeping Monsters",
        Summary = "Determines whether an attack on a sleeping monster wakes it.",
        DataType = "bool")]
    public virtual bool WakesSleepingMonsters { get; set; } = true;

    [ConfigurationMetadata(
        Title = "Item Projection Flag",
        Summary = "Determines whether the spell affects items through projection.",
        DataType = "bool")]
    public virtual bool ItemProjectionFlag { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Grid Projection Flag",
        Summary = "Determines whether the spell affects grids through projection.",
        DataType = "bool")]
    public virtual bool GridProjectionFlag { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Kill Projection Flag",
        Summary = "Determines whether the spell can kill through projection.",
        DataType = "bool")]
    public virtual bool KillProjectionFlag { get; set; } = true;

    [ConfigurationMetadata(
        Title = "Stop Projection Flag",
        Summary = "Determines whether the spell stops projection effects.",
        DataType = "bool")]
    public virtual bool StopProjectionFlag { get; set; } = true;

    [ConfigurationMetadata(
        Title = "Projectile Key",
        Summary = "Specifies the key for the projectile used by the spell.",
        DataType = "string")]
    public virtual string ProjectileKey { get; set; }

    [ConfigurationMetadata(
        Title = "Max Damage",
        Summary = "Specifies the maximum damage inflicted by the spell.",
        DataType = "int?")]
    public virtual int? MaxDamage { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Damage Roll Expression",
        Summary = "Specifies the roll expression used to determine the spell's damage.",
        DataType = "string")]
    public virtual string DamageRollExpression { get; set; }

    [ConfigurationMetadata(
        Title = "Inverse Radius",
        Summary = "Determines whether the spell uses an inverse radius.",
        DataType = "bool")]
    public virtual bool InverseRadius { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Radius Expression Text",
        Summary = "Specifies the expression used to calculate the spell's radius.",
        DataType = "string")]
    public virtual string RadiusExpressionText { get; set; } = "0";

    [ConfigurationMetadata(
        Title = "Pre-Execute On Player Script Binding Key",
        Summary = "Specifies the script binding key executed before the spell affects a player.",
        DataType = "string?")]
    public virtual string? PreExecuteOnPlayerScriptBindingKey { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Post-Execute On Player Script Binding Key",
        Summary = "Specifies the script binding key executed after the spell affects a player.",
        DataType = "string?")]
    public virtual string? PostExecuteOnPlayerScriptBindingKey { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Pre-Execute On Monster Script Binding Key",
        Summary = "Specifies the script binding key executed before the spell affects a monster.",
        DataType = "string?")]
    public virtual string? PreExecuteOnMonsterScriptBindingKey { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Post-Execute On Monster Script Binding Key",
        Summary = "Specifies the script binding key executed after the spell affects a monster.",
        DataType = "string?")]
    public virtual string? PostExecuteOnMonsterScriptBindingKey { get; set; } = null;
}
