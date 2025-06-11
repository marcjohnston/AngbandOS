namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ItemClassGameConfiguration
{
    public virtual string? Key { get; set; } = null;

    /// <summary>
    /// Returns the capitalized name of a singular item that the class represents.  This name can be used in a format like 'Your {0}'
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// Returns a description of the item class.  This is typically a plural version of the Name property.  This description is typically used to allow the player to select an item from
    /// the class.
    /// </summary>
    public virtual bool AllowStomp { get; set; } = true;

    public virtual int NumberOfFlavorsToGenerate { get; set; } = 0;

    /// <summary>
    /// Returns the repository to use for the issuance of the flavors or null, if the factory shouldn't be issued a flavor.  Null is returned
    /// when an item has a predefined flavor.  Apple juice, water and slime-mold item factories use pre-defined flavors. 
    /// </summary>
    public virtual string[]? ItemFlavorBindingKeys { get; set; } = null;
}
