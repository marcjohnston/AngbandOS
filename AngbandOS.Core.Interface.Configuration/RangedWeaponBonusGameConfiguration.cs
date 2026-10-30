// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RangedWeaponBonusGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { CharacterClassBindingKey, ItemClassBindingKey, ExperienceLevel == null ? null : ExperienceLevel.Value.ToString() }; // CONFIRMED

    [ConfigurationMetadata(
        Title = "Item Class Binding Key",
        Summary = "Specifies the optional binding key of the item class affected by the ranged weapon bonus.",
        DataType = "string?")]
    public virtual string? ItemClassBindingKey { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Character Class Binding Key",
        Summary = "Specifies the optional binding key of the character class affected by the ranged weapon bonus.",
        DataType = "string?")]
    public virtual string? CharacterClassBindingKey { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Experience Level",
        Summary = "Specifies the optional experience level at which the ranged weapon bonus applies.",
        DataType = "int?")]
    public virtual int? ExperienceLevel { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Bonus Missile Attacks Per Round",
        Summary = "Specifies the bonus number of missile attacks performed per round.",
        DataType = "int")]
    public virtual int BonusMissileAttacksPerRound { get; set; } = 0;
}
