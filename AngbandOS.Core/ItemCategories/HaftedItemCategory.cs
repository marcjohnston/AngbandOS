using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class HaftedItemCategory : MeleeWeaponItemCategory
    {
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Hafted;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightWhite;

        protected override bool CanBeWeaponOfLaw => true; 

        public override bool GetsDamageMultiplier => true;
    }
}
