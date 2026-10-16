// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntityAttribute(
    Title = "Dungeon",
    EntityNoun = "Dungeon")]
public class DungeonGameConfiguration : NonCompositeSingletonGameConfiguration
{
    /// <summary>
    /// Returns base offset (difficulty) for the dungeon.
    /// </summary>
    [ConfigurationMetadataAttribute(
        Title = "Base Offset",
        Summary = "The base offset, or difficulty, of the dungeon.",
        DataType = "int")]
    public virtual int BaseOffset { get; set; }

    /// <summary>
    /// Returns the name of the monster filter to be used for a bias for generating monsters; or null, if the dungeon has no
    /// biasness.  Returns null, by default.
    /// </summary>
    [ConfigurationMetadataAttribute(
        Title = "Bias Monster Filter Name",
        Summary = "The name of the monster filter used to bias monster generation, or null if the dungeon has no monster bias.",
        DataType = "string?")]
    public virtual string? BiasMonsterFilterName { get; set; } = null;

    /// <summary>
    /// Returns all of the quests associated to the dungeon.
    /// </summary>
    [ConfigurationMetadataAttribute(
        Title = "Dungeon Guardian Names",
        Summary = "The names of the dungeon guardians associated with the dungeon.",
        DataType = "string[]?")]
    public virtual string[]? DungeonGuardianNames { get; set; } = null;

    /// <summary>
    /// The symbol used for the dungeon on the wilderness map
    /// </summary>
    [ConfigurationMetadataAttribute(
        Title = "Map Symbol",
        Summary = "The symbol used to represent the dungeon on the wilderness map.",
        DataType = "string")]
    public virtual string MapSymbol { get; set; }

    /// <summary>
    /// The number of levels the dungeon has
    /// </summary>
    [ConfigurationMetadataAttribute(
        Title = "Max Level",
        Summary = "The maximum number of levels in the dungeon.",
        DataType = "int")]
    public virtual int MaxLevel { get; set; }

    /// <summary>
    /// The full name of the dungeon
    /// </summary>
    [ConfigurationMetadataAttribute(
        Title = "Name",
        Summary = "The full name of the dungeon.",
        DataType = "string")]
    public virtual string Name { get; set; }

    /// <summary>
    /// The shortened name of the dungeon for display purposes
    /// </summary>
    [ConfigurationMetadataAttribute(
        Title = "Shortname",
        Summary = "The shortened name of the dungeon used for display purposes.",
        DataType = "string")]
    public virtual string Shortname { get; set; }

    /// <summary>
    /// Returns true, if the dungeon is a tower; false, otherwise.  Returns false, by default.
    /// </summary>
    [ConfigurationMetadataAttribute(
        Title = "Tower",
        Summary = "Determines whether the dungeon is a tower.",
        DataType = "bool")]
    public virtual bool Tower { get; set; } = false;
}