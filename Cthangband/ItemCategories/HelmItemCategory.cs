using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class HelmItemCategory : ArmourItemCategory
    {
        public HelmItemCategory() : base(ItemCategory.Helm)
        {
        }
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBrown;

        //public override void ApplyMagic(Item item, int level, int power)
        //{
        //    if (power != 0 || item.ItemSubCategory == HelmType.SvDragonHelm)
        //    {
        //        base.ApplyMagic(item, level, power);
        //        if (item.ItemSubCategory == HelmType.SvDragonHelm)
        //        {
        //            if (SaveGame.Instance.Level != null)
        //            {
        //                SaveGame.Instance.Level.TreasureRating += 5;
        //            }
        //            ApplyDragonscaleResistance();
        //        }
        //        else
        //        {
        //            if (power > 1)
        //            {
        //                if (Program.Rng.DieRoll(20) == 1)
        //                {
        //                    item.CreateRandart(false);
        //                }
        //                else
        //                {
        //                    switch (Program.Rng.DieRoll(14))
        //                    {
        //                        case 1:
        //                        case 2:
        //                            {
        //                                item.RareItemTypeIndex = Enumerations.RareItemType.HatOfIntelligence;
        //                                break;
        //                            }
        //                        case 3:
        //                        case 4:
        //                            {
        //                                item.RareItemTypeIndex = Enumerations.RareItemType.HatOfWisdom;
        //                                break;
        //                            }
        //                        case 5:
        //                        case 6:
        //                            {
        //                                item.RareItemTypeIndex = Enumerations.RareItemType.HatOfBeauty;
        //                                break;
        //                            }
        //                        case 7:
        //                        case 8:
        //                            {
        //                                item.RareItemTypeIndex = Enumerations.RareItemType.HatOfSeeing;
        //                                if (Program.Rng.DieRoll(7) == 1)
        //                                {
        //                                    item.RandartFlags3.Set(ItemFlag3.Telepathy);
        //                                }
        //                                break;
        //                            }
        //                        case 9:
        //                        case 10:
        //                            {
        //                                item.RareItemTypeIndex = Enumerations.RareItemType.HatOfLight;
        //                                break;
        //                            }
        //                        default:
        //                            {
        //                                item.RareItemTypeIndex = Enumerations.RareItemType.HatOfInfravision;
        //                                break;
        //                            }
        //                    }
        //                }
        //            }
        //            else if (power < -1)
        //            {
        //                switch (Program.Rng.DieRoll(7))
        //                {
        //                    case 1:
        //                    case 2:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.HatOfStupidity;
        //                            break;
        //                        }
        //                    case 3:
        //                    case 4:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.HatOfNaivety;
        //                            break;
        //                        }
        //                    case 5:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.HatOfUgliness;
        //                            break;
        //                        }
        //                    case 6:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.HatOfSickliness;
        //                            break;
        //                        }
        //                    case 7:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.HatOfTeleportation;
        //                            break;
        //                        }
        //                }
        //            }
        //        }
        //    }
        //}

        public override bool CanReflectBoltsAndArrows => true;
    }
}
