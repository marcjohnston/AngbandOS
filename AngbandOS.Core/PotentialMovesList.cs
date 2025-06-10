// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// A matrix of possible moves that can be made by a monster
/// </summary>
[Serializable]
internal class PotentialMovesList
{
    private readonly int[] _values = new int[8];

    public int this[int index]
    {
        get => _values[index];
        set => _values[index] = value;
    }
}