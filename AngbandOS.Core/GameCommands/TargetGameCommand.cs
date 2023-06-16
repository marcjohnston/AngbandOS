namespace AngbandOS.Core.Commands;

/// <summary>
/// Select a target in advance for attacks. Note that this does not cost any in-game time
/// </summary>
[Serializable]
internal class TargetGameCommand : GameCommand
{
    private TargetGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => '*';

    public override bool Execute()
    {
        SaveGame.DoCmdTarget();
        return false;
    }
}
