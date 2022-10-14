using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class BowLightCrossbow : MissileWeaponItemCategory
    {
        public override char Character => '}';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Light Crossbow";

        public override int Chance1 => 1;
        public override int Cost => 140;
        public override string FriendlyName => "& Light Crossbow~";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override bool ShowMods => true;
        public override int Weight => 110;
        public override int MissileDamageMultiplier => 3;
        public override ItemCategory AmmunitionItemCategory => ItemCategory.Bolt;
    }
}
