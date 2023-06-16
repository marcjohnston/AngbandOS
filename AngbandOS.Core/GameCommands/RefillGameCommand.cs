namespace AngbandOS.Core.Commands;

/// <summary>
/// Refill a light source with fuel
/// </summary>
[Serializable]
internal class RefillGameCommand : GameCommand
{
    private RefillGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'F';

    public override bool Execute()
    {
        SaveGame.DoCmdRefill();
        return false;
    }
}
