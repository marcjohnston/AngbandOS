// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core;

[Serializable]
internal class PlayerHistory
{
    public readonly int Bonus;
    public readonly int Chart;
    public readonly string Info;
    public readonly int Next;
    public readonly int Roll;

    public PlayerHistory(string info, int roll, int chart, int next, int bonus)
    {
        Info = info;
        Roll = roll;
        Chart = chart;
        Next = next;
        Bonus = bonus;
    }
}