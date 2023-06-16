namespace AngbandOS.Core.Commands;

/// <summary>
/// Spend a turn searching for traps and secret doors
/// </summary>
[Serializable]
internal class SearchGameCommand : GameCommand
{
    private SearchGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 's';

    public override int? Repeat => null;

    public override bool Execute()
    {
        SaveGame.DoCmdSearch();
        return false;
    }
}
