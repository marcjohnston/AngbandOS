// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class CrownArmorItemFactory : ArmorItemFactory
{
    protected override void ApplyRandomGoodRareCharacteristics(Item item)
    {
        switch (Game.DieRoll(8))
        {
            case 1:
                item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(HatOfTheMagiRareItem));
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
                break;
            case 2:
                item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(HatOfMightRareItem));
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
                break;
            case 3:
                item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(HatOfTelepathyRareItem));
                break;
            case 4:
                item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(HatOfRegenerationRareItem));
                break;
            case 5:
            case 6:
                item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(HatOfLordlinessRareItem));
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
                break;
            case 7:
            case 8:
                item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(HatOfSeeingRareItem));
                if (Game.DieRoll(3) == 1)
                {
                    item.Characteristics.Telepathy = true;
                }
                break;
        }
    }

    protected override void ApplyRandomPoorRareCharacteristics(Item item)
    {
        item.RareItem = Game.SingletonRepository.Get<RareItemWeightedRandom>(nameof(CrownPoorRareItemWeightedRandom)).ChooseOrDefault();
    }

    public CrownArmorItemFactory(Game game) : base(game) { }
    /// <summary>
    /// Applies standard magic to crowns.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    public override void EnchantItem(Item item, int level, int power, Store? store)
    {
        if (power != 0)
        {
            // Apply the standard armor characteristics.
            base.EnchantItem(item, level, power, null);

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
