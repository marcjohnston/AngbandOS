using Cthangband.ArtifactBiases;
using Cthangband.Enumerations;

namespace Cthangband.ItemCategories
{
    internal class CrownItemCategory : ArmourItemCategory
    {
        //public override bool HatesAcid => true;

        //public override Colour Colour => Colour.BrightBrown;

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
        //                IArtifactBias artifactBias = null;
        //                switch (Program.Rng.DieRoll(8))
        //                {
        //                    case 1:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.HatOfTheMagi;
        //                            ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
        //                            break;
        //                        }
        //                    case 2:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.HatOfMight;
        //                            ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
        //                            break;
        //                        }
        //                    case 3:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.HatOfTelepathy;
        //                            break;
        //                        }
        //                    case 4:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.HatOfRegeneration;
        //                            break;
        //                        }
        //                    case 5:
        //                    case 6:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.HatOfLordliness;
        //                            ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
        //                            break;
        //                        }
        //                    default:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.HatOfSeeing;
        //                            if (Program.Rng.DieRoll(3) == 1)
        //                            {
        //                                item.RandartFlags3.Set(ItemFlag3.Telepathy);
        //                            }
        //                            break;
        //                        }
        //                }
        //            }
        //        }
        //        else if (power < -1)
        //        {
        //            switch (Program.Rng.DieRoll(7))
        //            {
        //                case 1:
        //                case 2:
        //                    {
        //                        item.RareItemTypeIndex = Enumerations.RareItemType.HatOfStupidity;
        //                        break;
        //                    }
        //                case 3:
        //                case 4:
        //                    {
        //                        item.RareItemTypeIndex = Enumerations.RareItemType.HatOfNaivety;
        //                        break;
        //                    }
        //                case 5:
        //                    {
        //                        item.RareItemTypeIndex = Enumerations.RareItemType.HatOfUgliness;
        //                        break;
        //                    }
        //                case 6:
        //                    {
        //                        item.RareItemTypeIndex = Enumerations.RareItemType.HatOfSickliness;
        //                        break;
        //                    }
        //                case 7:
        //                    {
        //                        item.RareItemTypeIndex = Enumerations.RareItemType.HatOfTeleportation;
        //                        break;
        //                    }
        //            }
        //        }
        //    }
        //}
    }
}
