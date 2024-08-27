// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class AmmunitionItemFactory : WeaponItemFactory
{
    public AmmunitionItemFactory(Game game) : base(game) { }

    public override int GetBonusRealValue(Item item)
    {
        int bonusValue = (item.BonusHit + item.BonusDamage) * 5;
        if (item.DamageDice > DamageDice && item.DamageSides == DamageSides)
        {
            bonusValue += (item.DamageDice - DamageDice) * item.DamageSides * 5;
        }
        return bonusValue;
    }
}
