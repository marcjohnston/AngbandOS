namespace AngbandOS.Core.Commands;

/// <summary>
/// Spike a door closed
/// </summary>
[Serializable]
internal class SpikeGameCommand : GameCommand
{
    private SpikeGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'j';

    public override bool Execute()
    {
        SaveGame.DoCmdSpike();
        return false;
    }
}
