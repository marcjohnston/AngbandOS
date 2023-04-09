namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class CloakArmorItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Cloak;
        public CloakArmorItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 22;
    }
}