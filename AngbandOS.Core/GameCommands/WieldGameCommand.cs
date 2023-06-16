namespace AngbandOS.Core.Commands;

/// <summary>
/// Wield/wear an item
/// </summary>
[Serializable]
internal class WieldGameCommand : GameCommand
{
    private WieldGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'w';

    public override bool Execute()
    {
        SaveGame.DoCmdWield();
        return false;
    }
}
