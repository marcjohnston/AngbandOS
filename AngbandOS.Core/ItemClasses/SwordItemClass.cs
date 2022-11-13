using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class SwordItemClass : MeleeWeaponItemClass
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
