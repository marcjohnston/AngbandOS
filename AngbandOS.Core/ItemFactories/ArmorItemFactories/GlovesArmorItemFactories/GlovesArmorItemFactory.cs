// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class GlovesArmorItemFactory : ArmorItemFactory
{
    public GlovesArmorItemFactory(Game game) : base(game) { }
    /// <summary>
    /// Applies a good random rare characteristics to gloves.
    /// </summary>
    /// <param name="item"></param>
    protected override void ApplyRandomGoodRareCharacteristics(Item item)
    {
        switch (Game.DieRoll(10))
        {
            case 1:
            case 2:
            case 3:
            case 4:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(GlovesOfFreeActionRareItem));
                break;
            case 5:
            case 6:
            case 7:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(GlovesOfSlayingRareItem));
                break;
            case 8:
            case 9:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(GlovesOfAgilityRareItem));
                break;
            case 10:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(GlovesOfPowerRareItem));
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
                break;
        }
    }

    /// <summary>
    /// Applies a poor random rare characteristics to gloves.
    /// </summary>
    /// <param name="item"></param>
    protected override void ApplyRandomPoorRareCharacteristics(Item item)
    {
        item.RareItem = Game.SingletonRepository.Get<RareItemWeightedRandom>(nameof(GlovesPoorRareItemWeightedRandom)).ChooseOrDefault();
    }

    /// <summary>
    /// Applies standard magic to gloves.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    public override void EnchantItem(Item item, bool usedOkay, int level, int power)
    {
        if (power != 0)
        {
            // Apply the standard armor characteristics.
            base.EnchantItem(item, usedOkay, level, power);

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
}
