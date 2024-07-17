// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class HardArmorItemFactory : ArmorItemFactory
{
    /// <summary>
    /// Applies standard magic to hard armor.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    public override void EnchantItem(Item item, bool usedOkay, int level, int power)
    {
        if (power != 0)
        {
            // Apply the standard armor characteristics.
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

            if (power > 1)
            {
                ApplyRandomGoodRareCharacteristics(item);
            }
        }
    }
    public HardArmorItemFactory(Game game) : base(game) { }
}
