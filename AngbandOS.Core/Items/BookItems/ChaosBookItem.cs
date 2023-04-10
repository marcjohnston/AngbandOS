namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ChaosBookItem : BookItem
    {
        public ChaosBookItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    }
}