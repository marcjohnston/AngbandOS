namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class CorporealBookItem : BookItem
    {
        public CorporealBookItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    }
}