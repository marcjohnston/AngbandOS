using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class SwordItemCategory : MeleeWeaponItemCategory
    {
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Sword;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightWhite;

        public override bool CanVorpalSlay => true;

        protected override bool CanBeWeaponOfLaw => true;
        protected override bool CanBeWeaponOfSharpness => true;
        protected override bool CapableOfVorpalSlaying => true;

        public override bool GetsDamageMultiplier => true;
    }
}
