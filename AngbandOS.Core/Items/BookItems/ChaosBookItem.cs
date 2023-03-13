namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ChaosBookItem : BookItem
    {
        public ChaosBookItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}