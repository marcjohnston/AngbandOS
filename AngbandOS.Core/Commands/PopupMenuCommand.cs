using Cthangband.Terminal;
using Cthangband.UI;
using System;
using System.Collections.Generic;

namespace Cthangband.Commands
{
    /// <summary>
    /// Fire the popup menu for quitting and changing options
    /// </summary>
    [Serializable]
    internal class PopupMenuCommand : ICommand
    {
        public char Key => '\x1b';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            var menuItems = new List<string>() { "Resume Game", "Quit to Menu", "Quit to Desktop" };
            var menu = new PopupMenu(menuItems);
            var result = menu.Show(saveGame);
            switch (result)
            {
                // Escape or Resume Game
                case -1:
                case 0:
                    return;
                // Quit to Menu
                case 1:
                    saveGame.Playing = false;
                    break;
                // Quit to Desktop
                case 2:
                    saveGame.Playing = false;
                    Program.ExitToDesktop = true;
                    break;
            }
        }
    }
}
