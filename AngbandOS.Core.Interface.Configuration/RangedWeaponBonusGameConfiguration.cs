// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class RangedWeaponBonusGameConfiguration
{
    /// <foreign-collection-name>Spells</foreign-collection-name>
    public virtual string? ItemClassBindingKey { get; set; } = null;
    /// <foreign-collection-name>CharacterClasses</foreign-collection-name>
    public virtual string? CharacterClassBindingKey { get; set; } = null;
    public virtual int? ExperienceLevel { get; set; } = null;
    public virtual int BonusMissileAttacksPerRound { get; set; } = 0;
}
