// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

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

    public int DisplayMenu(Game game)
    {
        var top = game.Screen.Height / 2 - (_items.Count + _text.Count) / 2;
        var left = game.Screen.Width / 2 - _menuWidth / 2;
        var topBottomBorder = "+" + new string('-', _menuWidth) + "+";
        var leftRightBorder = "|" + new string(' ', _menuWidth) + "|";
        var chosenItem = 0;
        game.Screen.Print(ColorEnum.White, topBottomBorder, top, left);
        for (int i = 0; i < _text.Count + _items.Count; i++)
        {
            game.Screen.Print(ColorEnum.White, leftRightBorder, top + i + 1, left);
        }
        game.Screen.Print(ColorEnum.White, topBottomBorder, top + _items.Count + _text.Count + 1, left);
        for (int i = 0; i < _text.Count; i++)
        {
            game.Screen.Print(ColorEnum.White, _text[i], top + i + 1, left + 1);
        }
        while (!game.Shutdown)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (i == chosenItem)
                {
                    game.Screen.Print(ColorEnum.BrightPurple, _chosenItems[i], top + _text.Count + i + 1, left + 1);
                }
                else
                {
                    game.Screen.Print(ColorEnum.White, _items[i], top + _text.Count + i + 1, left + 1);
                }
            }
            game.HideCursorOnFullScreenInkey = true;
            char k = game.Inkey();

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

    public int Show(Game game)
    {
        game.InPopupMenu = true;
        game.FullScreenOverlay = true;
        ScreenBuffer savedScreen = game.Screen.Clone();
        var result = DisplayMenu(game);
        game.Screen.Restore(savedScreen);
        game.InPopupMenu = false;
        game.FullScreenOverlay = false;
        return result;
    }
}