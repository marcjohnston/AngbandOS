namespace AngbandOS.Core.Commands;

[Serializable]
internal class CarriageReturnGameCommand : GameCommand
{
    private CarriageReturnGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => '\r';

    public override bool Execute()
    {
        return false;
    }
}
