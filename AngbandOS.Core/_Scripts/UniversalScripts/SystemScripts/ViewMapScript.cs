// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ViewMapScript : UniversalScript, IGetKey
{
    private ViewMapScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Executes the view map script.
    /// </summary>
    /// <returns></returns>
    public override void ExecuteScript()
    {
        int cy = -1;
        int cx = -1;
        Game.FullScreenOverlay = true;
        ScreenBuffer savedScreen = Game.Screen.Clone();
        Game.Screen.Clear();
        // If we're on the surface, display the island map
        if (Game.CurrentDepth == 0)
        {
            Game.SetBackground(BackgroundImageEnum.WildMap);
            Game.DisplayWildMap();
        }
        else
        {
            // We're not on the surface, so draw the level map
            Game.SetBackground(BackgroundImageEnum.Map);
            DisplayMap(out cy, out cx);
        }
        // Give us a prompt, and display the cursor in the player's location
        Game.Screen.Print(ColorEnum.Orange, "[Press any key to continue]", 43, 26);
        if (Game.CurrentDepth == 0)
        {
            Game.Screen.Goto(Game.WildernessY + 2, Game.WildernessX + 2);
        }
        else
        {
            Game.Screen.Goto(cy, cx);
        }
        // Wait for a keypress, and restore the screen (looking at the map takes no time)
        Game.Inkey();
        Game.Screen.Restore(savedScreen);
        Game.FullScreenOverlay = false;
        Game.SetBackground(BackgroundImageEnum.Overhead);
    }

    private const int _mapHgt = Game.MaxHgt / _ratio;
    private const int _mapWid = Game.MaxWid / _ratio;
    private const int _ratio = 3;

    public void DisplayMap(out int cy, out int cx)
    {
        int x, y, maxy;
        ColorEnum tempColor;
        char tempCharacter;
        ColorEnum[][] ma = new ColorEnum[_mapHgt + 2][];
        for (int i = 0; i < _mapHgt + 2; i++)
        {
            ma[i] = new ColorEnum[_mapWid + 2];
        }
        char[][] mc = new char[_mapHgt + 2][];
        for (int i = 0; i < _mapHgt + 2; i++)
        {
            mc[i] = new char[_mapWid + 2];
        }
        int[][] mp = new int[_mapHgt + 2][];
        for (int i = 0; i < _mapHgt + 2; i++)
        {
            mp[i] = new int[_mapWid + 2];
        }
        for (y = 0; y < _mapHgt + 2; ++y)
        {
            for (x = 0; x < _mapWid + 2; ++x)
            {
                ma[y][x] = ColorEnum.White;
                mc[y][x] = ' ';
                mp[y][x] = 0;
            }
        }
        int maxx = maxy = 0;
        for (int i = 0; i < Game.CurWid; ++i)
        {
            for (int j = 0; j < Game.CurHgt; ++j)
            {
                // Compute the zoomed out coordinate for this specific map location.
                x = (i / _ratio) + 1;
                y = (j / _ratio) + 1;
                if (x > maxx)
                {
                    maxx = x;
                }
                if (y > maxy)
                {
                    maxy = y;
                }

                // Determine the color and character of this specific map location.
                Game.MapInfo(j, i, out tempColor, out tempCharacter);

                // Get the priority of the specific map location.
                int tempPriority = Game.Map.Grid[j][i].FeatureType.MapPriority;
                if (tempColor == ColorEnum.Background)
                {
                    tempPriority = 0;
                }
                if (mp[y][x] < tempPriority)
                {
                    mc[y][x] = tempCharacter;
                    ma[y][x] = tempColor;
                    mp[y][x] = tempPriority;
                }
            }
        }
        x = maxx + 1;
        y = maxy + 1;
        int xOffset = (Game.Screen.Width - x) / 2;
        int yOffset = (Game.Screen.Height - 1 - y) / 2;
        mc[0][0] = '+';
        ma[0][0] = ColorEnum.Purple;
        mc[0][x] = '+';
        ma[0][x] = ColorEnum.Purple;
        mc[y][0] = '+';
        ma[y][0] = ColorEnum.Purple;
        mc[y][x] = '+';
        ma[y][x] = ColorEnum.Purple;
        for (x = 1; x <= maxx; x++)
        {
            mc[0][x] = '-';
            ma[0][x] = ColorEnum.Purple;
            mc[maxy + 1][x] = '-';
            ma[maxy + 1][x] = ColorEnum.Purple;
        }
        for (y = 1; y <= maxy; y++)
        {
            mc[y][0] = '|';
            ma[y][0] = ColorEnum.Purple;
            mc[y][maxx + 1] = '|';
            ma[y][maxx + 1] = ColorEnum.Purple;
        }
        for (y = 0; y < maxy + 2; ++y)
        {
            Game.Screen.Goto(yOffset + y, xOffset);
            for (x = 0; x < maxx + 2; ++x)
            {
                tempColor = ma[y][x];
                tempCharacter = mc[y][x];
                if (Game.InvulnerabilityTimer.Value != 0)
                {
                    tempColor = ColorEnum.White;
                }
                else if (Game.EtherealnessTimer.Value != 0)
                {
                    tempColor = ColorEnum.Black;
                }
                Game.Screen.Print(tempColor, tempCharacter.ToString());
            }
        }
        cy = yOffset + (Game.MapY.IntValue / _ratio) + 1;
        cx = xOffset + (Game.MapX.IntValue / _ratio) + 1;
    }
}
