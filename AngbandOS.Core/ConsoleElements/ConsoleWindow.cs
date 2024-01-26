// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ConsoleElements;

internal class ConsoleWindow
{
    public int Top => TopLeft.Y;
    public int Left => TopLeft.X;
    public int Bottom => BottomRight.Y;
    public int Right => BottomRight.X;
    public ConsoleLocation TopLeft { get; }
    public ConsoleLocation BottomRight { get; }
    public ConsoleLocation TopRight => new ConsoleLocation(Right, Top);
    public ConsoleLocation BottomLeft => new ConsoleLocation(Left, Bottom);

    public int Height => Bottom - Top + 1;

    public int Width => Right - Left + 1;

    public void Clear(SaveGame saveGame, ColorEnum color)
    {
        for (int y = Top; y <= Bottom; y++)
        {
            for (int x  = Left; x <= Right; x++)
            {
                saveGame.Screen.Print(color, ' ', y, x);
            }
        }
    }

    public ConsoleWindow(ConsoleLocation topLeft, ConsoleLocation bottomRight)
    {
        TopLeft = topLeft;
        BottomRight = bottomRight;
    }

    /// <summary>
    /// Creates a new ConsoleWindow object from top, left, right and bottom locations.
    /// </summary>
    /// <param name="left">The 0-based left location of the window.</param>
    /// <param name="top">The 0-based top location of the window.</param>
    /// <param name="right">The 0-based right side location of the window.</param>
    /// <param name="bottom">The 0-based bottom side location of the window.</param>
    public ConsoleWindow(int left, int top, int right, int bottom) : this(new ConsoleLocation(left, top), new ConsoleLocation(right, bottom)) { }

    public override string ToString()
    {
        return $"({TopLeft}-{BottomRight})";
    }
}
