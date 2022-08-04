using Cthangband.ArtifactBiases;
using Cthangband.Enumerations;
using System;
using static Cthangband.Extensions;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class BowItemCategory : WeaponItemCategory
    {
        public override bool HatesFire => true;
        public override bool HatesAcid => true;
        public override string GetDetailedDescription(Item item)
        {
            string basenm = "";
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            item.GetMergedFlags(f1, f2, f3);
            int power = item.ItemSubCategory % 10;
            if (f3.IsSet(ItemFlag3.XtraMight))
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
            else if(item.BaseArmourClass != 0)
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
                    item.RandartFlags3.Set(ItemFlag3.XtraMight);
                    if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = new RangerArtifactBias();
                    }
                    break;

                default:
                    item.RandartFlags3.Set(ItemFlag3.XtraShots);
                    if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = new RangerArtifactBias();
                    }
                    break;
            }
        }

        //public override void ApplyMagic(Item item, int level, int power)
        //{
        //    if (power != 0)
        //    {
        //        ApplyMagicToWeapon(item, level, power);
        //    }
        //}
    }
}
