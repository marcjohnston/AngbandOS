namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class DiggingWeaponItem : WeaponItem
    {
        public override int WieldSlot => InventorySlot.Digger;
        public DiggingWeaponItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override bool IdentityCanBeSensed => true;
        public override bool GetsDamageMultiplier => true;

        public override void ApplyMagic(int level, int power)
        {
            base.ApplyMagic( level, power);
            if (power > 1)
            {
                RareItemTypeIndex = RareItemTypeEnum.WeaponOfDigging;
            }
            else if (power < -1)
            {
                TypeSpecificValue = 0 - (5 + Program.Rng.DieRoll(5));
            }
            else if (power < 0)
            {
                TypeSpecificValue = 0 - TypeSpecificValue;
            }
        }
    }
}