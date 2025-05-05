using AngbandOS.Core.Interface.Configuration;

namespace AngbandOS.Core;

[Serializable]
internal class GenericItemClass : ItemClass
{
    public GenericItemClass(Game game, ItemClassGameConfiguration itemClassGameConfiguration) : base(game)
    {
        Key = itemClassGameConfiguration.Key ?? itemClassGameConfiguration.GetType().Name;
        Name = itemClassGameConfiguration.Name;
        AllowStomp = itemClassGameConfiguration.AllowStomp;
        NumberOfFlavorsToGenerate = itemClassGameConfiguration.NumberOfFlavorsToGenerate;
        ItemFlavorBindingKeys = itemClassGameConfiguration.ItemFlavorBindingKeys;
    }

    /// <summary>
    /// Returns the capitalized name of a singular item that the class represents.  This name can be used in a format like 'Your {0}'
    /// </summary>
    public override string Name { get; }

    /// <summary>
    /// Returns a description of the item class.  This is typically a plural version of the Name property.  This description is typically used to allow the player to select an item from
    /// the class.
    /// </summary>
    public override bool AllowStomp { get; } = true;

    public override int NumberOfFlavorsToGenerate { get; } = 0;

    /// <summary>
    /// Returns the repository to use for the issuance of the flavors or null, if the factory shouldn't be issued a flavor.  Null is returned
    /// when an item has a predefined flavor.  Apple juice, water and slime-mold item factories use pre-defined flavors. 
    /// </summary>
    protected override string[]? ItemFlavorBindingKeys { get; } = null;

    public override string Key { get; }
}

