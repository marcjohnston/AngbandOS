﻿using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class PolearmItemClass : MeleeWeaponItemClass
    {
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Polearm;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightWhite;

        public override bool GetsDamageMultiplier => true;
    }
}