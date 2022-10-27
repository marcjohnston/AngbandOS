using System;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Spend a turn searching for traps and secret doors
    /// </summary>
    [Serializable]
    internal class SearchCommand : ICommand
    {
        public char Key => 's';

        public int? Repeat => 99;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            saveGame.EnergyUse = 100;
            saveGame.Search();
        }
    }
}
