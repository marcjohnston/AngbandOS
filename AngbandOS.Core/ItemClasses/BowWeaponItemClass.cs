using static AngbandOS.Extensions;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class BowWeaponItemClass : WeaponItemClass // TODO: Should be renamed to RangedWeaponItemClass
    {
        public BowWeaponItemClass(SaveGame saveGame) : base(saveGame) { }
        public override int WieldSlot => InventorySlot.RangedWeapon;
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<RangedWeaponInventorySlot>();
        /// <summary>
        /// Returns a damage multiplier when the missile weapon is used.
        /// </summary>
        public virtual int MissileDamageMultiplier => 1;
        public override bool IdentityCanBeSensed => true;
        public override int? SubCategory => null; // The subcategory for all bows have been resolved.

        public abstract ItemTypeEnum AmmunitionItemCategory { get; }

        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Bow;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;
        public override string GetDetailedDescription(Item item)
        {
            string basenm = "";
            item.RefreshFlagBasedProperties();
            int power = item.ItemSubCategory % 10;
            if (XtraMight)
            {
                power++;
            }
            basenm += $" (x{power})";
            if (item.IsKnown())
            {
                basenm += $" ({GetSignedValue(item.BonusToHit)},{GetSignedValue(item.BonusDamage)})";

                if (item.BaseArmourClass != 0)
                {
                    // Add base armour class for all types of armour and when the base armour class is greater than zero.
                    basenm += $" [{item.BaseArmourClass},{GetSignedValue(item.BonusArmourClass)}]";
                }
                else if (item.BonusArmourClass != 0)
                {
                    // This is not armour, only show bonus armour class, if it is not zero and we know about it.
                    basenm += $" [{GetSignedValue(item.BonusArmourClass)}]";
                }
            }
            else if (item.BaseArmourClass != 0)
            {
                basenm += $" [{item.BaseArmourClass}]";
            }
            return basenm;
        }

        public override bool CanApplyBlowsBonus => false;

        public override Colour Colour => Colour.Brown;

        public override void ApplyRandomSlaying(ref IArtifactBias artifactBias, Item item)
        {
            switch (Program.Rng.DieRoll(6))
            {
                case 1:
                case 2:
                case 3:
                    item.RandartItemCharacteristics.XtraMight = true;
                    if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = new RangerArtifactBias();
                    }
                    break;

                default:
                    item.RandartItemCharacteristics.XtraShots = true;
                    if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = new RangerArtifactBias();
                    }
                    break;
            }
        }

        public override void ApplyMagic(Item item, int level, int power)
        {
            base.ApplyMagic(item, level, power);
            if (power > 1)
            {
                switch (Program.Rng.DieRoll(21))
                {
                    case 1:
                    case 11:
                        item.RareItemTypeIndex = Enumerations.RareItemType.BowOfExtraMight;
                        IArtifactBias artifactBias = null;
                        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(34) + 4);
                        break;
                    case 2:
                    case 12:
                        item.RareItemTypeIndex = Enumerations.RareItemType.BowOfExtraShots;
                        break;
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                        item.RareItemTypeIndex = Enumerations.RareItemType.BowOfVelocity;
                        break;
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                        item.RareItemTypeIndex = Enumerations.RareItemType.BowOfAccuracy;
                        break;
                    case 21:
                        item.CreateRandart(false);
                        break;
                }
            }
        }
    }
}
