﻿using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class CloakItemClass : ArmourItemClass
    {
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Cloak;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBrown;

        protected override void ApplyRandomGoodRareCharacteristics(Item item)
        {
            switch (Program.Rng.DieRoll(19))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfProtection;
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                    item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfStealth;
                    break;
                case 17:
                    item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfAman;
                    break;
                case 18:
                    item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfElectricity;
                    break;
                case 19:
                    item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfImmolation;
                    break;
            }
        }

        protected override void ApplyRandomPoorRareCharacteristics(Item item)
        {
            switch (Program.Rng.DieRoll(3))
            {
                case 1:
                    item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfIrritation;
                    break;
                case 2:
                    item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfVulnerability;
                    break;
                case 3:
                    item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfEnveloping;
                    break;
            }
        }

        public override void ApplyMagic(Item item, int level, int power)
        {
            if (power != 0)
            {
                // Apply the standard armour characteristics.
                base.ApplyMagic(item, level, power);

                if (item.ItemSubCategory == CloakType.SvElvenCloak)
                {
                    item.TypeSpecificValue = Program.Rng.DieRoll(4);
                }
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

        public override bool CanProvideSheathOfElectricity => true;

        public override bool CanProvideSheathOfFire => true;

        public override bool CanReflectBoltsAndArrows => true;
    }
}