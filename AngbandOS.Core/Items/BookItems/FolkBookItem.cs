namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class FolkBookItem : BookItem
    {
        public FolkBookItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}