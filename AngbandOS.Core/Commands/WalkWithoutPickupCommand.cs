namespace AngbandOS.Commands
{
    [Serializable]
    internal class WalkWithoutPickupCommand : ICommand
    {
        private WalkWithoutPickupCommand(SaveGame saveGame) { } // This object is a singleton.

        public char Key => '-';

        public int? Repeat => null;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            WalkAndPickupCommand.DoCmdWalk(saveGame, true);
        }
    }
}
