// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class DragonScaleMailArmorItemFactory : ArmorItemFactory
{
    public DragonScaleMailArmorItemFactory(Game game) : base(game) { }

    /// <summary>
    /// Returns true because broken armor should be stomped automatically. 
    /// </summary>
    public override bool InitialBrokenStomp => true;

    /// <summary>
    /// Returns false, because the player shouldn't be asked to stomp all Armor. 
    /// </summary>
    public override bool AskDestroyAll => false;

    public override bool HasQualityRatings => true;
    public override bool IsArmor => true;
    public override bool IdentityCanBeSensed => true;
    public override bool IsWearableOrWieldable => true;
    public override int RandartActivationChance => base.RandartActivationChance * 2;

    /// <summary>
    /// Returns true, for all armor where the armor class (ToA) is greater than or equal to zero.
    /// </summary>
    public override bool KindIsGood => BonusArmorClass >= 0;
    public override void EnchantItem(Item item, bool usedOkay, int level, int power)
    {
        int toac1 = Game.DieRoll(5) + item.GetBonusValue(5, level);
        int toac2 = item.GetBonusValue(10, level);
        if (power > 0)
        {
            item.BonusArmorClass += toac1;
            if (power > 1)
            {
                item.BonusArmorClass += toac2;
            }
        }
        else if (power < 0)
        {
            item.BonusArmorClass -= toac1;
            if (power < -1)
            {
                item.BonusArmorClass -= toac2;
            }
            if (item.BonusArmorClass < 0)
            {
                item.IsCursed = true;
            }
        }
    }
}
