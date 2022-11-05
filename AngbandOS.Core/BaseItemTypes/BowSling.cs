using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class BowSling : BowWeaponItemCategory
    {
        public override char Character => '}';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Sling";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 5;
        public override string FriendlyName => "& Sling~";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int Weight => 5;
        public override int MissileDamageMultiplier => 2;
        public override ItemCategory AmmunitionItemCategory => ItemCategory.Shot;
    }
}
