using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class PolearmItemCategory : MeleeWeaponItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.Polearm;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightWhite;

        public override bool GetsDamageMultiplier => true;
    }
}
