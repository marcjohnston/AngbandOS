namespace Cthangband.Commands
{
    internal class SpaceCommand : ICommand
    {
        public char Key => ' ';

        public bool Repeatable => false;

        public bool IsEnabled => true;

        public void Execute(Player player, Level level)
        {
        }
    }
}
