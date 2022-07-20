namespace Cthangband.Commands
{
    internal class CarriageReturnCommand : ICommand
    {
        public char Key => '\r';

        public bool Repeatable => false;

        public bool IsEnabled => true;

        public void Execute(Player player, Level level)
        {
        }
    }
}
