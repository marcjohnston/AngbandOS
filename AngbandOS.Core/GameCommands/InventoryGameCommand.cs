namespace AngbandOS.Core.Commands;

/// <summary>
/// Show the player's inventory
/// </summary>
[Serializable]
internal class InventoryGameCommand : GameCommand
{
    private InventoryGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'i';

    public override bool Execute()
    {
        SaveGame.DoCmdInventory();
        return false;
    }
}
