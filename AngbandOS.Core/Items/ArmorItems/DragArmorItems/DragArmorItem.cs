namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class DragArmorItem : ArmourItem
    {
        public DragArmorItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}