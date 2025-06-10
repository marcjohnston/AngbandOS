// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class CharacterClassSpellGameConfiguration
{
    /// <foreign-collection-name>Spells</foreign-collection-name>
    public virtual string SpellName { get; set; }
    /// <foreign-collection-name>CharacterClasses</foreign-collection-name>
    public virtual string CharacterClassName { get; set; }
    public virtual int Level { get; set; }
    public virtual int ManaCost { get; set; }
    public virtual int BaseFailure { get; set; }
    public virtual int FirstCastExperience { get; set; }
}
