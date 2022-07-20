using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Spend a turn searching for traps and secret doors
    /// </summary>
    [Serializable]
    internal class SearchCommand : ICommand
    {
        public char Key => 's';

        public bool Repeatable => true;

        public bool IsEnabled => false;

        public void Execute(Player player, Level level)
        {
            SaveGame.Instance.EnergyUse = 100;
            SaveGame.Instance.CommandEngine.Search();
        }
    }
}
