namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class ItemClass : IConfigurationItem
{
    protected readonly SaveGame SaveGame;
    protected ItemClass(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <inheritdoc />
    public virtual void Loaded() { }
    
    /// <inheritdoc />
    public virtual bool ExcludeFromRepository => false;

    public abstract string Description { get; }
    public virtual bool AllowStomp => true;
}