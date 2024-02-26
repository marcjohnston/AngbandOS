namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class ItemClass : IGetKey<string>
{
    protected readonly SaveGame SaveGame;
    protected ItemClass(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    /// <summary>
    /// Returns the capitalized name of a singular item that the class represents.  This name can be used in a format like 'Your {0}'
    /// </summary>
    public abstract string Name { get; }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Returns a description of the item class.  This is typically a plural version of the Name property.  This description is typically used to allow the player to select an item from
    /// the class.
    /// </summary>
    public virtual bool AllowStomp => true;
}