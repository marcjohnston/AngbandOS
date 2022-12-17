namespace AngbandOS.Commands
{
    internal class SpaceCommand : ICommand
    {
        private SpaceCommand() { } // This object is a singleton.

        public char Key => ' ';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
        }
    }
}
