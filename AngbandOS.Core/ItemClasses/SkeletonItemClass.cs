﻿using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class SkeletonItemClass : ItemClass
    {
        public override bool EasyKnow => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Skeleton;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.Beige;
        public override int PercentageBreakageChance => 50;
    }
}