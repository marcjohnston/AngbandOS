// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntityAttribute(
    Title = "Character Class Spell",
    EntityNoun = "Character Class Spell")]
public class CharacterClassSpellGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { CharacterClassName, SpellName }; // CONFIRMED

    [ConfigurationMetadataAttribute(
        Title = "Spell Name",
        Summary = "The name of the spell associated with the character class.",
        DataType = "string")]
    public virtual string SpellName { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Character Class Name",
        Summary = "The name of the character class associated with the spell.",
        DataType = "string")]
    public virtual string CharacterClassName { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Level",
        Summary = "The character class level at which the spell becomes available.",
        DataType = "int")]
    public virtual int Level { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Mana Cost",
        Summary = "The amount of mana required to cast the spell.",
        DataType = "int")]
    public virtual int ManaCost { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Base Failure",
        Summary = "The base chance that casting the spell will fail.",
        DataType = "int")]
    public virtual int BaseFailure { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "First Cast Experience",
        Summary = "The experience gained the first time the spell is cast.",
        DataType = "int")]
    public virtual int FirstCastExperience { get; set; }
}