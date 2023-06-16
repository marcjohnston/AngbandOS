namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class ChestItemClass : ItemFactory
{
    public ChestItemClass(SaveGame saveGame) : base(saveGame) { }
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Chest;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    /// <summary>
    /// Returns whether or not the chest is small.  Small chests have a 75% chance that the items in the chest are gold.  Large chest always return items.
    /// </summary>
    public abstract bool IsSmall { get; }
    public override int PackSort => 36;
    public abstract int NumberOfItemsContained { get; }

    public override Colour Colour => Colour.Grey;
}
