// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class BootsArmorItemFactory : ArmorItemFactory
{
    public BootsArmorItemFactory(Game game) : base(game) { }

    /// <summary>
    /// Applies standard magic to boots.
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
                if (Game.DieRoll(20) == 1)
                {
                    item.CreateRandomArtifact(false);
                }
                else
                {
                    ApplyRandomGoodRareCharacteristics(item);
                }
            }
            else if (power < -1)
            {
                ApplyRandomPoorRareCharacteristics(item);
            }
        }
    }

    protected override void ApplyRandomGoodRareCharacteristics(Item item)
    {
        switch (Game.DieRoll(24))
        {
            case 1:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(BootsOfSpeedRareItem));
                break;
            case 2:
            case 3:
            case 4:
            case 5:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(BootsOfFreeActionRareItem));
                break;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(BootsOfStealthRareItem));
                break;
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(BootsWingedRareItem));
                if (Game.DieRoll(2) == 1)
                {
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
                }
                break;
        }
    }

    /// <summary>
    /// Applies a poor random rare characteristics to boots.
    /// </summary>
    /// <param name="item"></param>
    protected override void ApplyRandomPoorRareCharacteristics(Item item)
    {
        switch (Game.DieRoll(3))
        {
            case 1:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(BootsOfNoiseRareItem));
                break;
            case 2:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(BootsOfSlownessRareItem));
                break;
            case 3:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(BootsOfAnnoyanceRareItem));
                break;
        }
    }
}
