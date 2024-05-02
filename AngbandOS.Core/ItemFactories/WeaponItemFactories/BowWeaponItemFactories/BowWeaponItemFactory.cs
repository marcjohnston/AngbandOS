// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class BowWeaponItemFactory : WeaponItemFactory // TODO: Should be renamed to RangedWeaponItemClass
{
    /// <summary>
    /// Returns the ranged weapon inventory slot for bows.
    /// </summary>
    public override int WieldSlot => InventorySlot.RangedWeapon;

    public override string GetDetailedDescription(Item item)
    {
        string basenm = "";
        item.RefreshFlagBasedProperties();
        int power = MissileDamageMultiplier;
        if (XtraMight)
        {
            power++;
        }
        basenm += $" (x{power})";
        if (item.IsKnown())
        {
            basenm += $" ({GetSignedValue(item.BonusToHit)},{GetSignedValue(item.BonusDamage)})";

            if (item.BaseArmorClass != 0)
            {
                // Add base armor class for all types of armor and when the base armor class is greater than zero.
                basenm += $" [{item.BaseArmorClass},{GetSignedValue(item.BonusArmorClass)}]";
            }
            else if (item.BonusArmorClass != 0)
            {
                // This is not armor, only show bonus armor class, if it is not zero and we know about it.
                basenm += $" [{GetSignedValue(item.BonusArmorClass)}]";
            }
        }
        else if (item.BaseArmorClass != 0)
        {
            basenm += $" [{item.BaseArmorClass}]";
        }
        return basenm;
    }

    public override void ApplyRandomSlaying(Item item, ref IArtifactBias artifactBias)
    {
        if (artifactBias != null)
        {
            if (artifactBias.ApplySlaying(item))
            {
                return;
            }
        }

        switch (Game.DieRoll(6))
        {
            case 1:
            case 2:
            case 3:
                item.RandomArtifactItemCharacteristics.XtraMight = true;
                if (artifactBias == null && Game.DieRoll(9) == 1)
                {
                    artifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RangerArtifactBias));
                }
                break;

            default:
                item.RandomArtifactItemCharacteristics.XtraShots = true;
                if (artifactBias == null && Game.DieRoll(9) == 1)
                {
                    artifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RangerArtifactBias));
                }
                break;
        }
    }

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        base.ApplyMagic(item, level, power, null);
        if (power > 1)
        {
            switch (Game.DieRoll(21))
            {
                case 1:
                case 11:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(BowOfExtraMightRareItem));
                    IArtifactBias artifactBias = null;
                    item.ApplyRandomResistance(ref artifactBias, Game.DieRoll(34) + 4);
                    break;
                case 2:
                case 12:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(BowOfExtraShotsRareItem));
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                case 13:
                case 14:
                case 15:
                case 16:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(BowOfVelocityRareItem));
                    break;
                case 7:
                case 8:
                case 9:
                case 10:
                case 17:
                case 18:
                case 19:
                case 20:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(BowOfAccuracyRareItem));
                    break;
                case 21:
                    item.CreateRandomArtifact(false);
                    break;
            }
        }
    }

    public BowWeaponItemFactory(Game game) : base(game) { }
    protected override string ItemClassName => nameof(BowsItemClass);
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(RangedWeaponInventorySlot));
    public override bool CanApplyBlowsBonus => true;
    /// <summary>
    /// Returns a damage multiplier when the missile weapon is used.
    /// </summary>
    public virtual int MissileDamageMultiplier => 1;

    public override int PackSort => 32;
    public abstract ItemTypeEnum AmmunitionItemCategory { get; }

    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Bow;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;
    public override ColorEnum Color => ColorEnum.Brown;
    public override bool CanApplyArtifactBiasSlaying => false;
}
