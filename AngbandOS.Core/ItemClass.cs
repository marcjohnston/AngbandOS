namespace AngbandOS.Core;

/// <summary>
/// Represents a class of items factories that are similar.  These classes define a distinct class name and stomp setting.
/// </summary>
[Serializable]
internal abstract class ItemClass : IGetKey
{
    protected readonly Game Game;
    protected ItemClass(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the capitalized name of a singular item that the class represents.  This name can be used in a format like 'Your {0}'
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Returns a description of the item class.  This is typically a plural version of the Name property.  This description is typically used to allow the player to select an item from
    /// the class.
    /// </summary>
    public virtual bool AllowStomp => true;

    public bool HasFlavor => (GetFlavorRepository != null);

    /// <summary>
    /// Returns the repository to use for the issuance of the flavors or null, if the factory shouldn't be issued a flavor.  Null is returned
    /// when an item has a predefined flavor.  Apple juice, water and slime-mold item factories use pre-defined flavors. 
    /// </summary>
    public virtual IEnumerable<Flavor>? GetFlavorRepository => null;

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public virtual void Bind() { }
}