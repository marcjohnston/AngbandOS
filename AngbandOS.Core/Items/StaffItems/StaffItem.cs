namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class StaffItem : Item
    {
        public StaffItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}