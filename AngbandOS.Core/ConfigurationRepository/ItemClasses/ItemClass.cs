namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class ItemClass : IGetKey<string>
{
    protected readonly SaveGame SaveGame;
    protected ItemClass(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public virtual void Bind() { }

    public abstract string Description { get; }
    public virtual bool AllowStomp => true;
}