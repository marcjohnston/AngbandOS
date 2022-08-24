// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using Cthangband.Enumerations;
using Cthangband.StaticData;
using Color = System.Drawing.Color;

namespace Cthangband.Terminal
{
    /// <summary>
    /// A pseudo-terminal
    /// </summary>
    [Serializable]
    internal class Terminal
    {
        [NonSerialized]
        private IConsole _console;

        /// <summary>
        /// Plays a sound
        /// </summary>
        /// <param name="val"> The sound to play </param>
        public void PlaySound(SoundEffect sound)
        {
            _console.PlaySound(sound);
        }

        public void PlayMusic(MusicTrack musicTrack)
        {
            _console.PlayMusic(musicTrack);
        }

        /// <summary>
        /// Opens a terminal window using the given parameters
        /// </summary>
        /// <param name="parameters"> The parameters for the terminal window </param>
        public Terminal(IConsole console)
        {
            _console = console;
        }

        public static string ToHex(Color c)
        {
            return $"#{c.A:X2}{c.R:X2}{c.G:X2}{c.B:X2}";
        }

        public void ShowCursor(int row, int col, char c, Color color)
        {
            _console.SetCellBackground(row, col, c, ToHex(color));
        }

        public void HideCursor(int row, int col, char c, Color color)
        {
            _console.UnsetCellBackground(row, col, c, ToHex(color));
        }

        /// <summary>
        /// Clears the entire screen
        /// </summary>
        public void Clear()
        {
            _console.Clear();
        }

        /// <summary>
        /// Prints text at the specified location in the specified colour
        /// </summary>
        /// <param name="row"> The row on which to print </param>
        /// <param name="col"> The column in which to start printing </param>
        /// <param name="text"> The text to print </param>
        /// <param name="colour"> The colour in which to print it </param>
        public void Print(int row, int col, string text, Color colour)
        {
            _console.Print(row, col, text, ToHex(colour));
        }

        /// <summary>
        /// Waits for a key to be pressed, and then returns that key
        /// </summary>
        /// <returns> The key that was pressed </returns>
        public char WaitForKey()
        {
            return _console.WaitForKey();
        }

        internal void SetBackground(BackgroundImage image)
        {
            _console.SetBackground(image);
        }
    }
}