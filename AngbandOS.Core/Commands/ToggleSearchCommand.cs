using AngbandOS.Enumerations;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Toggle whether we're automatically searching while moving
    /// </summary>
    [Serializable]
    internal class ToggleSearchCommand : ICommand
    {
        private ToggleSearchCommand(SaveGame saveGame) { } // This object is a singleton.

        public char Key => 'S';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            if (saveGame.Player.IsSearching)
            {
                saveGame.Player.IsSearching = false;
                saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
                saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrState);
            }
            else
            {
                saveGame.Player.IsSearching = true;
                saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
                saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrState | RedrawFlag.PrSpeed);
            }
        }
    }
}
