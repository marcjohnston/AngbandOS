namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class MushroomItem : Item
    {
        public MushroomItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}