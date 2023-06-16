namespace AngbandOS.Core.Commands;

/// <summary>
/// Fire the popup menu for quitting and changing options
/// </summary>
[Serializable]
internal class PopupMenuGameCommand : GameCommand
{
    private PopupMenuGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => '\x1b';

    public override bool Execute()
    {
        SaveGame.DoCmdPopup();
        return false;
    }
}
