namespace AngbandOS.Commands
{
    [Serializable]
    internal class CarriageReturnCommand : ICommand
    {
        private CarriageReturnCommand(SaveGame saveGame) { } // This object is a singleton.

        public char Key => '\r';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
        }
    }
}
