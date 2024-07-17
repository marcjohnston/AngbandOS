// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
/// <summary>
/// Represents weapon items.  Arrow, bolt, bow, digging, hafted, polearm, shot and swords are all weapon classes.
/// </summary>
internal abstract class WeaponItemFactory : ItemFactory
{
    public WeaponItemFactory(Game game) : base(game) { }

    /// <summary>
    /// Returns true because broken weapons should be stomped automatically. 
    /// </summary>
    public override bool InitialBrokenStomp => true;

    /// <summary>
    /// Returns false, because the player shouldn't be asked to stomp all Weapons. 
    /// </summary>
    public override bool AskDestroyAll => false;

    public override bool HasQualityRatings => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;

    public override void ApplyBonusForRandomArtifactCreation(RandomArtifactCharacteristics characteristics)
    {
        characteristics.BonusHit += Game.DieRoll(characteristics.BonusHit > 19 ? 1 : 20 - characteristics.BonusHit);
        characteristics.BonusDamage += Game.DieRoll(characteristics.BonusDamage > 19 ? 1 : 20 - characteristics.BonusDamage);
    }

    public override int GetBonusRealValue(Item item)
    {
        int bonusValue = 0;
        bonusValue += (item.BonusHit + item.BonusDamage + item.BonusArmorClass) * 100;
        if (item.DamageDice > DamageDice && item.DamageSides == DamageSides)
        {
            bonusValue += (item.DamageDice - DamageDice) * item.DamageSides * 100;
        }
        return bonusValue;
    }

    public override bool IdentityCanBeSensed => true;
    public override bool IsWeapon => true;
    public override bool IsWearableOrWieldable => true;

    /// <summary>
    /// Returns true, for all weapons where both the hit (ToH) and damage (ToD) are equal to or greater than zero.  False, for all weapons with either stat less than 0.
    /// </summary>
    public override bool KindIsGood
    {
        get
        {
            if (BonusHit < 0)
            {
                return false;
            }
            if (BonusDamage < 0)
            {
                return false;
            }
            return true;
        }
    }


    public override bool CanApplySlayingBonus => true;
}
