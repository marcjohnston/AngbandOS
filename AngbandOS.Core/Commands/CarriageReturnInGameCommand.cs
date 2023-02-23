namespace AngbandOS.Core.Commands
{
    [Serializable]
    internal class CarriageReturnInGameCommand : InGameCommand
    {
        private CarriageReturnInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '\r';

        public override bool Execute()
        {
            return false;
        }
    }
}
