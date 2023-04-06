namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class DeathBookItem : BookItem
    {
        public DeathBookItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 4;
    }
}