// Cthangband: � 1997 - 2022 Dean Anderson; Based on Angband: � 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: � 1985 Robert Alan Koeneke and Umoria: � 1989 James E.Wilson
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.RoomTypes
{
    [Serializable]
    internal class Room
    {
        public readonly int Dx1;
        public readonly int Dx2;
        public readonly int Dy1;
        public readonly int Dy2;
        public readonly int Level;

        public Room(int dy1, int dy2, int dx1, int dx2, int level)
        {
            Dy1 = dy1;
            Dy2 = dy2;
            Dx1 = dx1;
            Dx2 = dx2;
            Level = level;
        }
    }
}