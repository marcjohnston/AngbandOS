// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Towns
{
    [Serializable]
    internal abstract class Town
    {
        protected SaveGame SaveGame;

        public abstract char Char { get; }
        public abstract int HousePrice { get; }
        public abstract string Name { get; }
        public abstract Store[] Stores { get; }
        public int Index;

        /// <summary>
        /// Represents the RND seed that is used to generate the town.  This ensures the town is regenerated the same when the player returns.
        /// </summary>
        public int Seed = 0;
        public bool Visited = false;
        public int X = 0;
        public int Y = 0;

        protected Town(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }
    }
}