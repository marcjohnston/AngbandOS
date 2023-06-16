namespace AngbandOS.Core.StoreCommands;

/// <summary>
/// Let the player scroll through previous messages
/// </summary>
[Serializable]
internal class MessagesStoreCommand : BaseStoreCommand
{
    private MessagesStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char Key => 'P';

    public override string Description => "";

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        SaveGame.DoCmdMessages();
    }
}
