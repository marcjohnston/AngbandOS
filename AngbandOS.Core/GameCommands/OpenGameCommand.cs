namespace AngbandOS.Core.Commands;

/// <summary>
/// Open a door or chest
/// </summary>
[Serializable]
internal class OpenGameCommand : GameCommand
{
    private OpenGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'o';

    public override int? Repeat => 99;

    public override bool Execute()
    {
        return SaveGame.DoCmdOpen();
    }
}
