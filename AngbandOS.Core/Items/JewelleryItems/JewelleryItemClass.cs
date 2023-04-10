namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    /// <summary>
    /// Represents jewellery items.  Amulets and rings are both armour classes.
    /// </summary>
    internal abstract class JewelleryItemClass : ItemFactory
    {
        public JewelleryItemClass(SaveGame saveGame) : base(saveGame) { }
    }
}
