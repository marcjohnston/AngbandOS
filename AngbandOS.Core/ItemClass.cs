namespace AngbandOS.Core;

/// <summary>
/// Represents a class of items factories that are similar.  These classes define a distinct class name and stomp setting.
/// </summary>
[Serializable]
internal sealed class ItemClass : IGetKey, IToJson
{
    private readonly Game Game;
    public ItemClass(Game game, ItemClassGameConfiguration itemClassGameConfiguration)
    {
        Game = game;
        Key = itemClassGameConfiguration.Key ?? itemClassGameConfiguration.GetType().Name;
        Name = itemClassGameConfiguration.Name;
        AllowStomp = itemClassGameConfiguration.AllowStomp;
        NumberOfFlavorsToGenerate = itemClassGameConfiguration.NumberOfFlavorsToGenerate;
        ItemFlavorBindingKeys = itemClassGameConfiguration.ItemFlavorBindingKeys;
    }

    /// <summary>
    /// Returns the capitalized name of a singular item that the class represents.  This name can be used in a format like 'Your {0}'
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Returns a description of the item class.  This is typically a plural version of the Name property.  This description is typically used to allow the player to select an item from
    /// the class.
    /// </summary>
    public bool AllowStomp { get; } = true;

    public bool HasFlavor => (ItemFlavorRepository != null);

    public int NumberOfFlavorsToGenerate { get; } = 0;

    /// <summary>
    /// Returns the repository to use for the issuance of the flavors or null, if the factory shouldn't be issued a flavor.  Null is returned
    /// when an item has a predefined flavor.  Apple juice, water and slime-mold item factories use pre-defined flavors. 
    /// </summary>
    private string[]? ItemFlavorBindingKeys { get; } = null;

    public Flavor[]? ItemFlavorRepository { get; private set; }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        ItemClassGameConfiguration definition = new ItemClassGameConfiguration()
        {
            Key = Key,
            Name = Name,
            AllowStomp  = AllowStomp,
            NumberOfFlavorsToGenerate  = NumberOfFlavorsToGenerate,
            ItemFlavorBindingKeys  = ItemFlavorBindingKeys,
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    public string Key { get; }

    public string GetKey => Key;
    public void Bind()
    {
        ItemFlavorRepository = Game.SingletonRepository.GetNullable<ItemFlavor>(ItemFlavorBindingKeys);
    }
}

