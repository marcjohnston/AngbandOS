namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class CorporealBookItem : BookItem
    {
        public CorporealBookItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}