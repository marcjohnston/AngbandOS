namespace AngbandOS.Core.Commands;

/// <summary>
/// Use a down staircase or trapdoor
/// </summary>
[Serializable]
internal class GoDownGameCommand : GameCommand
{
    private GoDownGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => '>';

    public override bool Execute()
    {
        SaveGame.DoGoDown();
        return false;
    }
}
