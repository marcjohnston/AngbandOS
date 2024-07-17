// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class ShieldArmorItemFactory : ArmorItemFactory
{
    /// <summary>
    /// Applies a good random rare characteristics to a shield.
    /// </summary>
    protected override void ApplyRandomGoodRareCharacteristics(Item item)
    {
        switch (Game.DieRoll(23))
        {
            case 1:
            case 11:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ShieldOfResistAcidRareItem));
                break;
            case 2:
            case 3:
            case 4:
            case 12:
            case 13:
            case 14:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ShieldOfResistLightningRareItem));
                break;
            case 5:
            case 6:
            case 15:
            case 16:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ShieldOfResistFireRareItem));
                break;
            case 7:
            case 8:
            case 9:
            case 17:
            case 18:
            case 19:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ShieldOfResistColdRareItem));
                break;
            case 10:
            case 20:
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(ResistanceAndBiasItemAdditiveBundleWeightedRandom)));
                if (Game.DieRoll(4) == 1)
                {
                    item.Characteristics.ResPois = true;
                }
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ShieldOfResistanceRareItem));
                break;
            case 21:
            case 22:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ShieldOfReflectionRareItem));
                break;
            case 23:
                item.CreateRandomArtifact(false);
                break;
        }
    }

    /// <summary>
    /// Applies standard magic to shields.
    /// </summary>
    /// <param name="level"></param>
    /// <param name="power"></param>
    /// <param name="store"></param>
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
    public ShieldArmorItemFactory(Game game) : base(game) { }
}
