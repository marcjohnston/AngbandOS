using AngbandOS.Core;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Fire the popup menu for quitting and changing options
    /// </summary>
    [Serializable]
    internal class PopupMenuCommand : ICommand
    {
        private PopupMenuCommand(SaveGame saveGame) { } // This object is a singleton.

        public char Key => '\x1b';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            var menuItems = new List<string>() { "Resume Game", "Save and Quit" };
            var menu = new PopupMenu(menuItems);
            var result = menu.Show(saveGame);
            switch (result)
            {
                // Escape or Resume Game
                case -1:
                case 0:
                    return;
                // Save and Quit
                case 1:
                    saveGame.Playing = false;
                    break;
            }
        }
    }
}
