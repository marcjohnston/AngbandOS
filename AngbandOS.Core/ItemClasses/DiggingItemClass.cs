namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class DiggingItemClass : WeaponItemClass
    {
        public DiggingItemClass(SaveGame saveGame) : base(saveGame) { }
        public override int WieldSlot => InventorySlot.Digger;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Digging;
        public override bool IdentityCanBeSensed => true;
        public override Colour Colour => Colour.Grey;

        public override void ApplyMagic(Item item, int level, int power)
        {
            base.ApplyMagic(item, level, power);
            if (power > 1)
            {
                item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfDigging;
            }
            else if (power < -1)
            {
                item.TypeSpecificValue = 0 - (5 + Program.Rng.DieRoll(5));
            }
            else if (power < 0)
            {
                item.TypeSpecificValue = 0 - item.TypeSpecificValue;
            }
        }

        public override bool GetsDamageMultiplier => true;
        public override int? SubCategory => null; // Not used anymore
    }
}
