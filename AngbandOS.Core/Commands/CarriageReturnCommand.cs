namespace AngbandOS.Commands
{
    [Serializable]
    internal class CarriageReturnCommand : Command
    {
        private CarriageReturnCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '\r';

        public override bool Execute()
        {
            return false;
        }
    }
}
