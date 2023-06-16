namespace AngbandOS.Core.Commands;

[Serializable]
internal class WalkAndPickupGameCommand : GameCommand
{
    private WalkAndPickupGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => ';';

    public override int? Repeat => null;

    public override bool Execute()
    {
        return SaveGame.DoCmdWalk(false);
    }
}
