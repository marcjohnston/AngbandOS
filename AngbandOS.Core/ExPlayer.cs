// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Races;

namespace AngbandOS
{
    /// <summary>
    /// A dead player character, holding just the bare bones needed for the high score table and
    /// savegame preview, or to create a new character based on the previous one.
    /// </summary>
    [Serializable]
    internal class ExPlayer
    {
        /// <summary>
        /// The index of the character's gender
        /// </summary>
        public readonly int GenderIndex;

        /// <summary>
        /// The character's generation, to be appended to their name
        /// </summary>
        public readonly int Generation;

        /// <summary>
        /// The level at which the character died
        /// </summary>
        public readonly int Level;

        /// <summary>
        /// The name of the character
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The profession of the character
        /// </summary>
        public readonly int ProfessionIndex;

        /// <summary>
        /// The race of the character
        /// </summary>
        public readonly Race Race;

        /// <summary>
        /// The race the character was born with (they might have been polymorphed or mutated)
        /// </summary>
        public readonly Race RaceAtBirth;

        /// <summary>
        /// The character's first realm of magic (if any)
        /// </summary>
        public readonly Realm Realm1;

        /// <summary>
        /// The character's second realm of magic (if any)
        /// </summary>
        public readonly Realm Realm2;

        /// <summary>
        /// Make an ex-player from a player, remembering the essential information about the character
        /// </summary>
        /// <param name="player"> The player character from which to create the ex player </param>
        public ExPlayer(Player player)
        {
            GenderIndex = player.GenderIndex;
            Race = player.Race;
            RaceAtBirth = player.RaceAtBirth;
            ProfessionIndex = player.ProfessionIndex;
            Realm1 = player.Realm1;
            Realm2 = player.Realm2;
            Name = player.Name;
            Level = player.Level;
            Generation = player.Generation;
        }
    }
}