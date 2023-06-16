// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class TargetLocation : IComparable<TargetLocation>
{
    public readonly int X;
    public readonly int Y;

    private readonly int _distance;

    public TargetLocation(int y, int x, int distance)
    {
        X = x;
        Y = y;
        _distance = distance;
    }

    public int CompareTo(TargetLocation other)
    {
        return _distance.CompareTo(other._distance);
    }
}