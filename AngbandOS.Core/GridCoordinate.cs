// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// A simple immutable coordinate, stored in a reference type so it can be passed from function to function.
/// </summary>
[Serializable]
internal class GridCoordinate
{
    public int X { get; }
    public int Y { get; }

    public GridCoordinate Clone()
    {
        return new GridCoordinate(X, Y);
    }

    public GridCoordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
}