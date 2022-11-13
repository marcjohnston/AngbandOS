using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class BowHeavyCrossbow : BowWeaponItemCategory
    {
        public override char Character => '}';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Heavy Crossbow";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 300;
        public override string FriendlyName => "& Heavy Crossbow~";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int Weight => 200;
        public override int MissileDamageMultiplier => 4;
        public override ItemTypeEnum AmmunitionItemCategory => ItemTypeEnum.Bolt;
    }
}
