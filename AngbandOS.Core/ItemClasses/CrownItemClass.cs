using AngbandOS.Core.Interface;
using AngbandOS.ArtifactBiases;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class CrownItemClass : ArmourItemClass
    {
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Crown;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBrown;
        public override int? SubCategory => null; // No longer used.

        protected override void ApplyRandomGoodRareCharacteristics(Item item)
        {
            IArtifactBias artifactBias = null;
            switch (Program.Rng.DieRoll(8))
            {
                case 1:
                    item.RareItemTypeIndex = Enumerations.RareItemType.HatOfTheMagi;
                    item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                    break;
                case 2:
                    item.RareItemTypeIndex = Enumerations.RareItemType.HatOfMight;
                    item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                    break;
                case 3:
                    item.RareItemTypeIndex = Enumerations.RareItemType.HatOfTelepathy;
                    break;
                case 4:
                    item.RareItemTypeIndex = Enumerations.RareItemType.HatOfRegeneration;
                    break;
                case 5:
                case 6:
                    item.RareItemTypeIndex = Enumerations.RareItemType.HatOfLordliness;
                    item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                    break;
                case 7:
                case 8:
                    item.RareItemTypeIndex = Enumerations.RareItemType.HatOfSeeing;
                    if (Program.Rng.DieRoll(3) == 1)
                    {
                        item.RandartItemCharacteristics.Telepathy = true;
                    }
                    break;
            }
        }

        protected override void ApplyRandomPoorRareCharacteristics(Item item)
        {
            switch (Program.Rng.DieRoll(7))
            {
                case 1:
                case 2:
                    item.RareItemTypeIndex = Enumerations.RareItemType.HatOfStupidity;
                    break;
                case 3:
                case 4:
                    item.RareItemTypeIndex = Enumerations.RareItemType.HatOfNaivety;
                    break;
                case 5:
                    item.RareItemTypeIndex = Enumerations.RareItemType.HatOfUgliness;
                    break;
                case 6:
                    item.RareItemTypeIndex = Enumerations.RareItemType.HatOfSickliness;
                    break;
                case 7:
                    item.RareItemTypeIndex = Enumerations.RareItemType.HatOfTeleportation;
                    break;
            }
        }

        /// <summary>
        /// Applies standard magic to crowns.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="level"></param>
        /// <param name="power"></param>
        public override void ApplyMagic(Item item, int level, int power)
        {
            if (power != 0)
            {
                // Apply the standard armour characteristics.
                base.ApplyMagic(item, level, power);

                if (power > 1)
                {
                    if (Program.Rng.DieRoll(20) == 1)
                    {
                        item.CreateRandart(false);
                    }
                    else
                    {
                        ApplyRandomGoodRareCharacteristics(item);
                    }
                }
                else if (power < -1)
                {
                    ApplyRandomPoorRareCharacteristics(item);
                }
            }
        }
    }
}
