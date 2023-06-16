namespace AngbandOS.Core.Commands;

/// <summary>
/// Enter a store
/// </summary>
[Serializable]
internal class StoreGameCommand : GameCommand
{
    private StoreGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => '_';

    public override bool Execute()
    {
        SaveGame.DoCmdStore();
        return false;
    }
}
