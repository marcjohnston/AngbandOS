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
internal abstract class WeaponItemClass : ItemFactory
{
    public WeaponItemClass(SaveGame saveGame) : base(saveGame) { }
    public override bool HasQuality => true;

    public override bool IsWeapon => true;
    public override bool IsWearable => true;

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

    public override bool CanApplyTunnelBonus => true;
}
