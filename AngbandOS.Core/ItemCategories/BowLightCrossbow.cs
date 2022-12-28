using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class BowLightCrossbow : BowWeaponItemClass
    {
        public BowLightCrossbow(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '}';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Light Crossbow";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 140;
        public override string FriendlyName => "& Light Crossbow~";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int Weight => 110;
        public override int MissileDamageMultiplier => 3;
        public override ItemTypeEnum AmmunitionItemCategory => ItemTypeEnum.Bolt;
    }
}
