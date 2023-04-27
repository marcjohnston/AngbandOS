namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    /// <summary>
    /// Represents jewellery items.  Amulets and rings are both armour classes.
    /// </summary>
    internal abstract class JewelleryItemFactory : ItemFactory
    {
        public JewelleryItemFactory(SaveGame saveGame) : base(saveGame) { }
    }
}
