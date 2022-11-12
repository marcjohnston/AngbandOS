using AngbandOS.Core.Interface;
using AngbandOS.ArtifactBiases;
using AngbandOS.Enumerations;

using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class BootsItemCategory : ArmourItemClass
    {
        public override ItemCategory CategoryEnum => ItemCategory.Boots;
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
        //                switch (Program.Rng.DieRoll(24))
        //                {
        //                    case 1:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfSpeed;
        //                            break;
        //                        }
        //                    case 2:
        //                    case 3:
        //                    case 4:
        //                    case 5:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfFreeAction;
        //                            break;
        //                        }
        //                    case 6:
        //                    case 7:
        //                    case 8:
        //                    case 9:
        //                    case 10:
        //                    case 11:
        //                    case 12:
        //                    case 13:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfStealth;
        //                            break;
        //                        }
        //                    default:
        //                        {
        //                            IArtifactBias artifactBias = null;
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.BootsWinged;
        //                            if (Program.Rng.DieRoll(2) == 1)
        //                            {
        //                                ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
        //                            }
        //                            break;
        //                        }
        //                }
        //            }
        //        }
        //        else if (power < -1)
        //        {
        //            switch (Program.Rng.DieRoll(3))
        //            {
        //                case 1:
        //                    {
        //                        item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfNoise;
        //                        break;
        //                    }
        //                case 2:
        //                    {
        //                        item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfSlowness;
        //                        break;
        //                    }
        //                case 3:
        //                    {
        //                        item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfAnnoyance;
        //                        break;
        //                    }
        //            }
        //        }
        //    }
        //}
    }
}
