using Cthangband.ArtifactBiases;
using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class GlovesItemCategory : ArmourItemCategory
    {
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBrown;

        //public override void ApplyMagic(Item item, int level, int power)
        //{
        //    if (power != 0)
        //    {
        //        base.ApplyMagic(item, level, power);
        //        if (power > 1)
        //        {
        //            if (Program.Rng.DieRoll(20) == 1)
        //            {
        //                item.CreateRandart(false);
        //            }
        //            else
        //            {
        //                switch (Program.Rng.DieRoll(10))
        //                {
        //                    case 1:
        //                    case 2:
        //                    case 3:
        //                    case 4:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfFreeAction;
        //                            break;
        //                        }
        //                    case 5:
        //                    case 6:
        //                    case 7:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfSlaying;
        //                            break;
        //                        }
        //                    case 8:
        //                    case 9:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfAgility;
        //                            break;
        //                        }
        //                    case 10:
        //                        {
        //                            IArtifactBias artifactBias = null;
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfPower;
        //                            ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
        //                            break;
        //                        }
        //                }
        //            }
        //        }
        //        else if (power < -1)
        //        {
        //            switch (Program.Rng.DieRoll(2))
        //            {
        //                case 1:
        //                    {
        //                        item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfClumsiness;
        //                        break;
        //                    }
        //                default:
        //                    {
        //                        item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfWeakness;
        //                        break;
        //                    }
        //            }
        //        }
        //    }
        //}
    }
}
