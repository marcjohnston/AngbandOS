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

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
namespace Cthangband.Terminal
{
    /// <summary>
    /// A pseudo-terminal
    /// </summary>
    [Serializable]
    internal class Terminal
    {
        private string _cursorBrushColor;
        private int _cursorCol;
        private int _cursorRow;
        private bool _cursorVisible;

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
            CursorVisible = false;
            CursorRow = 0;
            CursorCol = 0;
        }

        /// <summary>
        /// Sets or returns the column in which the cursor lies
        /// </summary>
        private int CursorCol
        {
            get => _cursorCol;
            set
            {
                if (_cursorVisible)
                {
                    if (CursorRow >= 0 && CursorRow < Constants.ConsoleHeight && CursorCol >= 0 && CursorCol < Constants.ConsoleWidth)
                    {
                   //     _console.SetCellBackground(CursorRow, CursorCol, null);
                    }
                }
                _cursorCol = value;
                if (_cursorVisible)
                {
                    if (CursorRow >= 0 && CursorRow < Constants.ConsoleHeight && CursorCol >= 0 && CursorCol < Constants.ConsoleWidth)
                    {
               //         _console.SetCellBackground(CursorRow, CursorCol, _cursorBrushColor);
                    }
                }
            }
        }

        public static string ToHex(Color c)
        {
            return $"#{c.A:X2}{c.R:X2}{c.G:X2}{c.B:X2}";
        }

        /// <summary>
        /// Sets or returns the row in which the cursor lies
        /// </summary>
        private int CursorRow
        {
            get => _cursorRow;
            set
            {
                if (_cursorVisible)
                {
                    if (CursorRow >= 0 && CursorRow < Constants.ConsoleHeight && CursorCol >= 0 && CursorCol < Constants.ConsoleWidth)
                    {
              //          _console.SetCellBackground(CursorRow, CursorCol, null);
                    }
                }
                _cursorRow = value;
                if (_cursorVisible)
                {
                    if (CursorRow >= 0 && CursorRow < Constants.ConsoleHeight && CursorCol >= 0 && CursorCol < Constants.ConsoleWidth)
                    {
             //           _console.SetCellBackground(CursorRow, CursorCol, _cursorBrushColor);
                    }
                }
            }
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
        /// Sets or returns whether the cursor is visible
        /// </summary>
        public bool CursorVisible
        {
            get => _cursorVisible;
            set
            {
                _cursorVisible = value;
                if (_cursorVisible)
                {
                    if (CursorRow >= 0 && CursorRow < Constants.ConsoleHeight && CursorCol >= 0 && CursorCol < Constants.ConsoleWidth)
                    {
               //         _console.SetCellBackground(CursorRow, CursorCol, _cursorBrushColor);
                    }
                }
                else
                {
                    if (CursorRow >= 0 && CursorRow < Constants.ConsoleHeight && CursorCol >= 0 && CursorCol < Constants.ConsoleWidth)
                    {
             //           _console.SetCellBackground(CursorRow, CursorCol, null);
                    }
                }
            }
        }

        /// <summary>
        /// Clears the entire screen
        /// </summary>
        public void Clear()
        {
            _console.Clear();
        }

        /// <summary>
        /// Moves the cursor to the specified location
        /// </summary>
        /// <param name="row"> The row on which to place the cursor </param>
        /// <param name="col"> The column on which to place the cursor </param>
        public void Goto(int row, int col)
        {
            CursorRow = row;
            CursorCol = col;
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
            CursorRow = row;
            CursorCol = col;
            _console.Print(row, col, text, ToHex(colour));
            CursorCol += text.Length;
        }

        public void Refresh()
        {
            //_window.InvalidateVisual();
            //Application.DoEvents();
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