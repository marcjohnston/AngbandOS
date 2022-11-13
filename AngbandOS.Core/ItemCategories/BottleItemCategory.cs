using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class BottleItemCategory : ItemClass
    {
        public override bool EasyKnow => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Bottle;
        public override bool HatesCold => true;
        public override bool HatesAcid => true;

        public override int PercentageBreakageChance => 100;
    }
}
