// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core
{
    internal class PopupMenu
    {
        private readonly List<string> _chosenItems;
        private readonly List<string> _items;
        private readonly int _menuWidth;
        private readonly List<string> _text;

        internal PopupMenu(List<string> items, List<string> text = null, int width = 22)
        {
            _menuWidth = width;
            _text = new List<string>();
            if (text != null)
            {
                foreach (var line in text)
                {
                    _text.Add(line.PadCenter(_menuWidth));
                }
            }
            _items = new List<string>();
            _chosenItems = new List<string>();
            foreach (var item in items)
            {
                _items.Add(item.PadCenter(_menuWidth));
                _chosenItems.Add(("* " + item + " *").PadCenter(_menuWidth));
            }
        }

        public int DisplayMenu(SaveGame saveGame)
        {
            var top = Constants.ConsoleHeight / 2 - (_items.Count + _text.Count) / 2;
            var left = Constants.ConsoleWidth / 2 - _menuWidth / 2;
            var topBottomBorder = "+" + new string('-', _menuWidth) + "+";
            var leftRightBorder = "|" + new string(' ', _menuWidth) + "|";
            var chosenItem = 0;
            saveGame.Print(Colour.White, topBottomBorder, top, left);
            for (int i = 0; i < _text.Count + _items.Count; i++)
            {
                saveGame.Print(Colour.White, leftRightBorder, top + i + 1, left);
            }
            saveGame.Print(Colour.White, topBottomBorder, top + _items.Count + _text.Count + 1, left);
            for (int i = 0; i < _text.Count; i++)
            {
                saveGame.Print(Colour.White, _text[i], top + i + 1, left + 1);
            }
            while (true && !saveGame.Shutdown)
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    if (i == chosenItem)
                    {
                        saveGame.Print(Colour.BrightPurple, _chosenItems[i], top + _text.Count + i + 1, left + 1);
                    }
                    else
                    {
                        saveGame.Print(Colour.White, _items[i], top + _text.Count + i + 1, left + 1);
                    }
                }
                saveGame.HideCursorOnFullScreenInkey = true;
                char k = saveGame.Inkey();

                switch (k)
                {
                    case '\x1b':
                        return -1;

                    case '\r':
                    case ' ':
                        return chosenItem;

                    case '2':
                        chosenItem++;
                        if (chosenItem == _items.Count)
                        {
                            chosenItem = 0;
                        }
                        break;

                    case '8':
                        chosenItem--;
                        if (chosenItem == -1)
                        {
                            chosenItem = _items.Count - 1;
                        }
                        break;
                }
            }
            return -1;
        }

        public int Show(SaveGame saveGame)
        {
            saveGame.InPopupMenu = true;
            saveGame.FullScreenOverlay = true;
            saveGame.SaveScreen();
            var result = DisplayMenu(saveGame);
            saveGame.Load();
            saveGame.InPopupMenu = false;
            saveGame.FullScreenOverlay = false;
            return result;
        }
    }
}