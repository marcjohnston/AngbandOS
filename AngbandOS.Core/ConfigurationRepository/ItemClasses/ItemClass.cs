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

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    public abstract string Description { get; }
    public virtual bool AllowStomp => true;
}