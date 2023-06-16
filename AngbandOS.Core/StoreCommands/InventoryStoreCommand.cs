namespace AngbandOS.Core.StoreCommands;

/// <summary>
/// Show the player's inventory
/// </summary>
[Serializable]
internal class InventoryStoreCommand : BaseStoreCommand
{
    private InventoryStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char Key => 'i';

    public override string Description => "";

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        SaveGame.DoCmdInventory();
    }
}
