namespace AngbandOS.Core.StoreCommands;

/// <summary>
/// Destroy a single item
/// </summary>
[Serializable]
internal class DestroyStoreCommand : BaseStoreCommand
{
    private DestroyStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char Key => 'k';

    public override string Description => "";

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        SaveGame.DoCmdDestroy();
    }
}
