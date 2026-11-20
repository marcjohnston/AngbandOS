// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class CharacterClassSpellGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { CharacterClassName, SpellName }; // CONFIRMED

    [ConfigurationProperty("string",
        Title = "Spell Name",
        Summary = "The name of the spell associated with the character class.")]
    public virtual string SpellName { get; set; }

    [ConfigurationProperty("string",
        Title = "Character Class Name",
        Summary = "The name of the character class associated with the spell.")]
    public virtual string CharacterClassName { get; set; }

    [ConfigurationProperty("int",
        Title = "Level",
        Summary = "The character class level at which the spell becomes available.")]
    public virtual int Level { get; set; }

    [ConfigurationProperty("int",
        Title = "Mana Cost",
        Summary = "The amount of mana required to cast the spell.")]
    public virtual int ManaCost { get; set; }

    [ConfigurationProperty("int",
        Title = "Base Failure",
        Summary = "The base chance that casting the spell will fail.")]
    public virtual int BaseFailure { get; set; }

    [ConfigurationProperty("int",
        Title = "First Cast Experience",
        Summary = "The experience gained the first time the spell is cast.")]
    public virtual int FirstCastExperience { get; set; }
}