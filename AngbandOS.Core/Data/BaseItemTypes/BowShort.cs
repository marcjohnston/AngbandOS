using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class BowShort : MissileWeaponItemCategory
    {
        public override char Character => '}';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Short Bow";

        public override int Chance1 => 1;
        public override int Cost => 50;
        public override string FriendlyName => "& Short Bow~";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override bool ShowMods => true;
        public override int Weight => 30;
        public override int MissileDamageMultiplier => 2;
        public override ItemCategory AmmunitionItemCategory => ItemCategory.Arrow;

    }
}
