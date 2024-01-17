namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class ItemClass
{
    protected readonly SaveGame SaveGame;
    protected ItemClass(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public abstract string Description { get; }
    public virtual bool AllowStomp => true;
}