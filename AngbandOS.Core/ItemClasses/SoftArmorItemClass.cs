﻿using AngbandOS.Core.Interface;
using AngbandOS.ArtifactBiases;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class SoftArmorItemClass : ArmourItemClass
    {
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.SoftArmor;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.Grey;

        /// <summary>
        /// Applies standard magic to soft armour.
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
                    ApplyRandomGoodRareCharacteristics(item);
                }
            }
        }

        public override bool CanProvideSheathOfElectricity => true;

        public override bool CanProvideSheathOfFire => true;
    }
}