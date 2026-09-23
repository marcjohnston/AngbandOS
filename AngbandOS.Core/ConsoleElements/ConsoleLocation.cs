// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ConsoleElements;

/// <summary>
/// Represents a location in a console window.  This class is immutable.
/// </summary>
internal class ConsoleLocation
{
    /// <summary>
    /// The 0-based x-coordinate for the location on the console.
    /// </summary>
    public int X { get; }

    /// <summary>
    /// The 0-based y-coordinate for the location on the console.
    /// </summary>
    public int Y { get; }

    public ConsoleLocation Clone() => new ConsoleLocation(X, Y);

    public ConsoleWindow ToWindow(int width, int height)
    {
        if (width <= 0 || height <= 0)
        {
            throw new Exception("ConsoleLocation.ToWindow cannot have zero width or height.");
        }
        return new ConsoleWindow(this, this.Offset(width - 1, height - 1));
    }

    public ConsoleLocation Offset(int x, int y) => new ConsoleLocation(X + x, Y + y);

    public ConsoleLocation(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"{X},{Y}";
    }
}
