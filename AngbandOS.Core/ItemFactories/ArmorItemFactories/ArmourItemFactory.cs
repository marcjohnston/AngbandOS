// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.ItemFactories;

[Serializable]
/// <summary>
/// Represents armor items.  Boots, cloaks, crowns, dragon armor, gloves, hard armor, helm, shield and soft armor are all armor classes.
/// </summary>
internal abstract class ArmorItemFactory : ItemFactory
{
    public ArmorItemFactory(Game game) : base(game) { }

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (100, "3d5-3")
    };

    public override void ApplyBonusForRandomArtifactCreation(Item item)
    {
        item.BonusArmorClass += Game.DieRoll(item.BonusArmorClass > 19 ? 1 : 20 - item.BonusArmorClass);
    }

    public override int GetBonusRealValue(Item item)
    {
        return (item.BonusHit + item.BonusDamage + item.BonusArmorClass) * 100;
    }

    public void ApplyDragonscaleResistance(Item item)
    {
        do
        {
            if (Game.DieRoll(4) == 1)
            {
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(NaturalAndPoisonResistanceItemAdditiveBundleWeightedRandom)));
            }
            else
            {
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
            }
        } while (Game.DieRoll(2) == 1);
    }

    protected override void ApplyRandomGoodRareCharacteristics(Item item)
    {
        switch (Game.DieRoll(21))
        {
            case 1:
            case 2:
            case 3:
            case 4:
                item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(ArmorOfResistAcidRareItem));
                break;
            case 5:
            case 6:
            case 7:
            case 8:
                item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(ArmorOfResistLightningRareItem));
                break;
            case 9:
            case 10:
            case 11:
            case 12:
                item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(ArmorOfResistFireRareItem));
                break;
            case 13:
            case 14:
            case 15:
            case 16:
                item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(ArmorOfResistColdRareItem));
                break;
            case 17:
            case 18:
                item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(ArmorOfResistanceRareItem));
                if (Game.DieRoll(4) == 1)
                {
                    item.Characteristics.ResPois = true;
                }
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
                break;
            case 19:
                item.CreateRandomArtifact(false);
                break;
            case 20:
            case 21:
                item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(ArmorOfYithRareItem));
                break;
        }
    }

    /// <summary>
    /// Applies a standard BonusArmorClass and IdentCursed to armor class items.  Derived items must call this base to have these
    /// standard characteristics applied, when needed.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
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
