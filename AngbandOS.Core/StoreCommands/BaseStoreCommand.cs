namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal abstract class BaseStoreCommand
{
    protected SaveGame SaveGame { get; }
    protected BaseStoreCommand(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }
    public abstract char Key { get; }
    public virtual bool IsEnabled(Store store) => true;
    public abstract void Execute(StoreCommandEvent storeCommandEvent);
    public abstract string Description { get; }
}
