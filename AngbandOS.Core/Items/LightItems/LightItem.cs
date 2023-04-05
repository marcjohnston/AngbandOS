namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class LightItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Lightsource;
        public LightItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}