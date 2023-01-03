// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS
{
    [Serializable]
    internal class StoreOwner
    {
        public readonly int MaxCost;
        public readonly int MinInflate;
        public readonly string OwnerName;

        /// <summary>
        /// Returns the race of the store owner.  Null, if there is no store owner.
        /// </summary>
        public readonly Race? OwnerRace;

        public StoreOwner(string ownerName, int maxCost, int minInflate, Race? ownerRace)
        {
            OwnerName = ownerName;
            MaxCost = maxCost;
            MinInflate = minInflate;
            OwnerRace = ownerRace;
        }
    }
}