namespace AngbandOS.Core.Symbols;

[Serializable]
internal abstract class Symbol : IConfigurationItem
{
    protected readonly SaveGame SaveGame;
    protected Symbol(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <inheritdoc />
    public virtual void Loaded() { }

    /// <inheritdoc />
    public virtual bool ExcludeFromRepository => false;
    
    public abstract char Character { get; }
    public virtual char QueryCharacter => Character;
    public abstract string Name { get; }
}
