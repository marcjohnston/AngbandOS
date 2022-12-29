using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class HaftedItemClass : MeleeWeaponItemClass
    {
        public HaftedItemClass(SaveGame saveGame) : base(saveGame) { }
        public override int WieldSlot => InventorySlot.MeleeWeapon;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Hafted;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightWhite;

        protected override bool CanBeWeaponOfLaw => true;

        public override bool GetsDamageMultiplier => true;
    }
}
