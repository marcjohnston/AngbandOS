using Cthangband.ArtifactBiases;
using Cthangband.Enumerations;

namespace Cthangband.ItemCategories
{
    internal class SoftArmorItemCategory : ArmourItemCategory
    {
        //public override bool HatesFire => true;
        //public override bool HatesAcid => true;

        //public override Colour Colour => Colour.Grey;

        //public override void ApplyMagic(Item item, int level, int power)
        //{
        //    if (power != 0)
        //    {
        //        base.ApplyMagic(item, level, power);
        //        if (power > 1)
        //        {
        //            if (item.ItemSubCategory == SoftArmourType.SvRobe && Program.Rng.RandomLessThan(100) < 10)
        //            {
        //                item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfPermanence;
        //            }
        //            else
        //            {
        //                switch (Program.Rng.DieRoll(21))
        //                {
        //                    case 1:
        //                    case 2:
        //                    case 3:
        //                    case 4:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistAcid;
        //                            break;
        //                        }
        //                    case 5:
        //                    case 6:
        //                    case 7:
        //                    case 8:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistLightning;
        //                            break;
        //                        }
        //                    case 9:
        //                    case 10:
        //                    case 11:
        //                    case 12:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistFire;
        //                            break;
        //                        }
        //                    case 13:
        //                    case 14:
        //                    case 15:
        //                    case 16:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistCold;
        //                            break;
        //                        }
        //                    case 17:
        //                    case 18:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistance;
        //                            if (Program.Rng.DieRoll(4) == 1)
        //                            {
        //                                item.RandartFlags2.Set(ItemFlag2.ResPois);
        //                            }
        //                            IArtifactBias artifactBias = null;
        //                            ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
        //                            break;
        //                        }
        //                    case 20:
        //                    case 21:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfYith;
        //                            break;
        //                        }
        //                    default:
        //                        {
        //                            item.CreateRandart(false);
        //                            break;
        //                        }
        //                }
        //            }
        //        }
        //    }
        //}
        //public override bool CanProvideSheathOfElectricity => true;

        //public override bool CanProvideSheathOfFire => true;
    }
}
