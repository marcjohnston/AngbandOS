namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class SorceryBookItem : BookItem
    {
        public SorceryBookItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    }
}