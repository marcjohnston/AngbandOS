// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class HelmArmorItemFactory : ArmorItemFactory
{

    /// <summary>
    /// Applies standard magic to helms.
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
    protected override void ApplyRandomGoodRareCharacteristics(Item item)
    {
        switch (Game.DieRoll(14))
        {
            case 1:
            case 2:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfIntelligenceRareItem));
                break;
            case 3:
            case 4:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfWisdomRareItem));
                break;
            case 5:
            case 6:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfBeautyRareItem));
                break;
            case 7:
            case 8:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfSeeingRareItem));
                if (Game.DieRoll(7) == 1)
                {
                    item.Characteristics.Telepathy = true;
                }
                break;
            case 9:
            case 10:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfLightRareItem));
                break;
            case 11:
            case 12:
            case 13:
            case 14:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfInfravisionRareItem));
                break;
        }
    }

    public HelmArmorItemFactory(Game game) : base(game) { }

    protected override void ApplyRandomPoorRareCharacteristics(Item item)
    {
        item.RareItem = Game.SingletonRepository.Get<RareItemWeightedRandom>(nameof(HelmPoorRareItemWeightedRandom)).ChooseOrDefault();
    }
}
