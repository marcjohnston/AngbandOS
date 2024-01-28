// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
/// <summary>
/// Represents weapon items.  Arrow, bolt, bow, digging, hafted, polearm, shot and swords are all weapon classes.
/// </summary>
internal abstract class WeaponItemFactory : ItemFactory
{
    public WeaponItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override bool HasQuality => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;


    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (power == 0)
        {
            return;
        }

        int tohit1 = SaveGame.Rng.DieRoll(5) + item.GetBonusValue(5, level);
        int todam1 = SaveGame.Rng.DieRoll(5) + item.GetBonusValue(5, level);
        int tohit2 = item.GetBonusValue(10, level);
        int todam2 = item.GetBonusValue(10, level);
        if (power > 0)
        {
            item.BonusToHit += tohit1;
            item.BonusDamage += todam1;
            if (power > 1)
            {
                item.BonusToHit += tohit2;
                item.BonusDamage += todam2;
            }
        }
        else if (power < 0)
        {
            item.BonusToHit -= tohit1;
            item.BonusDamage -= todam1;
            if (power < -1)
            {
                item.BonusToHit -= tohit2;
                item.BonusDamage -= todam2;
            }
            if (item.BonusToHit + item.BonusDamage < 0)
            {
                item.IdentCursed = true;
            }
        }
    }

    public override bool IdentityCanBeSensed => true;
    public override bool IsWeapon => true;
    public override bool IsWearable => true;

    public override bool ItemsCanBeMerged(Item a, Item b)
    {
        if (!base.ItemsCanBeMerged(a, b))
        {
            return false;
        }
        if (!StatsAreSame(a, b))
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Returns true, for all weapons where both the hit (ToH) and damage (ToD) are equal to or greater than zero.  False, for all weapons with either stat less than 0.
    /// </summary>
    public override bool KindIsGood
    {
        get
        {
            if (ToH < 0)
            {
                return false;
            }
            if (ToD < 0)
            {
                return false;
            }
            return true;
        }
    }


    public override bool CanApplySlayingBonus => true;
}
