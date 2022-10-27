using AngbandOS.Core.Interface;
using AngbandOS.ArtifactBiases;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class ShieldItemCategory : ArmourItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.Shield;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBrown;

        //public override void ApplyMagic(Item item, int level, int power)
        //{
        //    if (power != 0 || item.ItemSubCategory == ShieldType.SvDragonShield)
        //    {
        //        base.ApplyMagic(item, level, power);
        //        if (item.ItemSubCategory == ShieldType.SvDragonShield)
        //        {
        //            if (item.SaveGame.Level != null)
        //            {
        //                item.SaveGame.Level.TreasureRating += 5;
        //            }
        //            ApplyDragonscaleResistance();
        //        }
        //        else
        //        {
        //            if (power > 1)
        //            {
        //                switch (Program.Rng.DieRoll(23))
        //                {
        //                    case 1:
        //                    case 11:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistAcid;
        //                            break;
        //                        }
        //                    case 2:
        //                    case 3:
        //                    case 4:
        //                    case 12:
        //                    case 13:
        //                    case 14:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistLightning;
        //                            break;
        //                        }
        //                    case 5:
        //                    case 6:
        //                    case 15:
        //                    case 16:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistFire;
        //                            break;
        //                        }
        //                    case 7:
        //                    case 8:
        //                    case 9:
        //                    case 17:
        //                    case 18:
        //                    case 19:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistCold;
        //                            break;
        //                        }
        //                    case 10:
        //                    case 20:
        //                        {
        //                            IArtifactBias artifactBias = null;
        //                            ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(34) + 4);
        //                            if (Program.Rng.DieRoll(4) == 1)
        //                            {
        //                                item.RandartFlags2.Set(ItemFlag2.ResPois);
        //                            }
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistance;
        //                            break;
        //                        }
        //                    case 21:
        //                    case 22:
        //                        {
        //                            item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfReflection;
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

        public override bool CanReflectBoltsAndArrows => true;
    }
}
