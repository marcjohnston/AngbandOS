using Cthangband.ArtifactBiases;
using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal abstract class DragArmorItemCategory : ArmourItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.DragArmor;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.Grey;

        //public override void ApplyMagic(Item item, int level, int power)
        //{
        //    if (power != 0)
        //    {
        //        base.ApplyMagic(item, level, power);
        //        if (SaveGame.Instance.Level != null)
        //        {
        //            SaveGame.Instance.Level.TreasureRating += 30;
        //        }
        //    }
        //}

        public override string DescribeActivationEffect(Item item)
        {
            switch (item.ItemSubCategory)
            {
                case DragonArmour.SvDragonBlue:
                    return "breathe lightning (100) every 450+d450 turns";
                case DragonArmour.SvDragonWhite:
                    return "breathe frost (110) every 450+d450 turns";
                case DragonArmour.SvDragonBlack:
                    return "breathe acid (130) every 450+d450 turns";
                case DragonArmour.SvDragonGreen:
                    return "breathe poison gas (150) every 450+d450 turns";
                case DragonArmour.SvDragonRed:
                    return "breathe fire (200) every 450+d450 turns";
                case DragonArmour.SvDragonMultihued:
                    return "breathe multi-hued (250) every 225+d225 turns";
                case DragonArmour.SvDragonBronze:
                    return "breathe confusion (120) every 450+d450 turns";
                case DragonArmour.SvDragonGold:
                    return "breathe sound (130) every 450+d450 turns";
                case DragonArmour.SvDragonChaos:
                    return "breathe chaos/disenchant (220) every 300+d300 turns";
                case DragonArmour.SvDragonLaw:
                    return "breathe sound/shards (230) every 300+d300 turns";
                case DragonArmour.SvDragonBalance:
                    return "You breathe balance (250) every 300+d300 turns";
                case DragonArmour.SvDragonShining:
                    return "breathe light/darkness (200) every 300+d300 turns";
                case DragonArmour.SvDragonPower:
                    return "breathe the elements (300) every 300+d300 turns";
                default:
                    return "some unknown effect"; // This is a change from the original code ... at least we will render something.
            }
        }
    }
}
