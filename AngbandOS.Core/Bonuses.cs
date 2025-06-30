// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal class Bonuses
{
    public int BaseArmorClass { get; init; } = 0;
    public int AttackBonus {get; init; } = 0;
    public int DamageBonus { get; init; } = 0;
    public int DisplayedAttackBonus { get; init; } = 0;
    public int DisplayedDamageBonus { get; init; } = 0;
    public bool HasUnpriestlyWeapon {get; init; } = false;
    public bool HasHeavyBow { get; init; } = false;

    public Bonuses Merge(Bonuses bonuses)
    {
        return new Bonuses()
        {
            BaseArmorClass = BaseArmorClass + bonuses.BaseArmorClass,
            AttackBonus = AttackBonus + bonuses.AttackBonus,
            DamageBonus = AttackBonus + bonuses.DamageBonus,
            DisplayedAttackBonus = DisplayedAttackBonus + bonuses.DisplayedAttackBonus,
            DisplayedDamageBonus = DisplayedDamageBonus + bonuses.DisplayedDamageBonus,
            HasUnpriestlyWeapon = HasUnpriestlyWeapon || bonuses.HasUnpriestlyWeapon,
            HasHeavyBow = HasHeavyBow | bonuses.HasHeavyBow,
        };
    }
}
