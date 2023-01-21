// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core
{
    [Serializable]
    internal class Screen
    {
        /// <summary>
        /// A window that represents modified contents.
        /// </summary>
        private UpdateWindow UpdateWindow;

        public Colour AttrBlank;
        public char CharBlank;

        /// <summary>
        /// The height of the screen.
        /// </summary>
        private int Height;

        /// <summary>
        /// The width of the screen.
        /// </summary>
        private int Width;

        private readonly int[] A; // Represents fast character index into Va for each row.  0, 80, 160 etc ...  // Was a pointer to part of va, now an index into it // TODO: not sure if this is needed anymore
        private readonly int[] C; // Was a pointer to part of va, now an index into it
        private readonly Colour[] Va; // Array of color data for the entire screen
        private readonly char[] Vc; // Array of character data for the entire screen

        /// <summary>
        /// True, if a clear command was issued.  This flag forces a screen clear event to be emitted to the client and all screen contents redrawn when the UpdateScreen method runs.
        /// </summary>
        private bool TotalErase;

        /// <summary>
        /// Whether or nt the cursor is visible.  Encapsulated using the CursorVisible property.
        /// </summary>
        private bool _cursorVisible; // TODO: Combine this into a GridCoordinate? (nullable)
        
        /// <summary>
        /// The x coordinate position of the cursor.
        /// </summary>
        private int Cx; // TODO: Combine this into a GridCoordinate? (nullable)

        /// <summary>
        /// The y coordinate position of the cursor.
        /// </summary>
        private int Cy; // TODO: Combine this into a GridCoordinate? (nullable)

        /// <summary>
        /// Returns the current cursor position.
        /// </summary>
        public GridCoordinate CursorPosition => new GridCoordinate(Cx, Cy);

        /// <summary>
        /// Sets or returns whether the cursor is visible
        /// </summary>
        public bool CursorVisible
        {
            get => _cursorVisible;
            set => _cursorVisible = value;
        }

        /// <summary>
        /// Moves the cursor and print location to a new position
        /// </summary>
        /// <param name="row"> The row at which to print </param>
        /// <param name="col"> The column at which to print </param>
        public void Goto(int row, int col)
        {
            if (col < 0 || col >= Width)
            {
                return;
            }
            if (row < 0 || row >= Height)
            {
                return;
            }
            Cx = col;
            Cy = row;
        }

        public void Clear()
        {
            Cx = 0;
            Cy = 0;
            for (int y = 0; y < Height; y++)
            {
                int scrAa = A[y];
                int scrCc = C[y];
                for (int x = 0; x < Width; x++)
                {
                    Va[scrAa + x] = AttrBlank;
                    Vc[scrCc + x] = CharBlank;
                }
            }
            UpdateWindow.Reset();
            TotalErase = true;
        }

        /// <summary>
        /// Clears the screen from the specified row downwards
        /// </summary>
        /// <param name="row"> The first row to clear </param>
        public void Clear(int row)
        {
            for (int y = row; y < Height; y++)
            {
                Erase(y, 0);
            }
        }

        public Screen(int w, int h)
        {
            Width = w;
            Height = h;

            UpdateWindow = new UpdateWindow(Width, Height);

            AttrBlank = 0;
            CharBlank = ' ';

            TotalErase = true;

            Va = new Colour[h * w];
            Vc = new char[h * w];

            // Initialize A, C, Va and Vc.  A and C are character indexes for each row so that we do not have to multiply.
            A = new int[h];
            C = new int[h];
            for (int y = 0; y < h; y++)
            {
                A[y] = w * y;
                C[y] = w * y;
            }
        }

        public Screen Clone()
        {
            Screen f = new Screen(Width, Height);
            for (int y = 0; y < Height; y++)
            {
                int fAa = f.A[y];
                int fCc = f.C[y];
                int sAa = A[y];
                int sCc = C[y];
                for (int x = 0; x < Width; x++)
                {
                    f.Va[sAa++] = Va[fAa++];
                    f.Vc[sCc++] = Vc[fCc++];
                }
            }
            f.Cx = Cx;
            f.Cy = Cy;
            f.CursorVisible = CursorVisible;
            return f;
        }

        /// <summary>
        /// Re-loads a saved screen to the GUI
        /// </summary>
        public void Restore(Screen f)
        {
            for (int y = 0; y < Height; y++)
            {
                int fAa = f.A[y];
                int fCc = f.C[y];
                int sAa = A[y];
                int sCc = C[y];
                for (int x = 0; x < Width; x++)
                {
                    Va[sAa++] = f.Va[fAa++];
                    Vc[sCc++] = f.Vc[fCc++];
                }
            }
            Cx = f.Cx;
            Cy = f.Cy;
            CursorVisible = f.CursorVisible;
            UpdateWindow.Reset();
        }

        /// <summary>
        /// Update the screen using a double buffer.  Only the window portion of the screen is checked.  The update window will be reverse reset so that no update would happen.
        /// </summary>
        public void UpdateScreen(Screen old, IConsole console)
        {
            // All commands to be sent to the console will be queued into a single response.
            List<PrintLine> batchPrintLines = new List<PrintLine>();

            if (TotalErase)
            {
                // Emit a clear to the console.
                console.Clear();

                // Clear out the double buffer so that all screen updates will write.
                old.Clear();

                // Reset the update window to check the entire screen.
                UpdateWindow.Reset();

                // The erase has been processed.
                TotalErase = false;
            }

            // Check to see if any updates are needed.
            if (UpdateWindow.Y1 > UpdateWindow.Y2 && CursorVisible == old.CursorVisible && Cx == old.Cx && Cy == old.Cy)
            {
                // No updates are needed.
                return;
            }

            // Check to see if the cursor position needs to be updated.
            if (old.CursorVisible && (!CursorVisible || old.Cx != Cx || old.Cy != Cy))
            {
                // Turn off the old cursor position.
                int indexForOldCursor = old.C[old.Cy] + old.Cx; // This is the index to the row of characters in the screen array.
                batchPrintLines.Add(new PrintLine(old.Cy, old.Cx, old.Vc[indexForOldCursor].ToString(), old.Va[indexForOldCursor], Colour.Background));
            }

            // Loop through each row of the entire "defined" display.  It may be smaller than the full 45 rows.
            for (int y = UpdateWindow.Y1; y <= UpdateWindow.Y2; ++y)
            {
                int x1 = UpdateWindow.X1[y];
                int x2 = UpdateWindow.X2[y];
                if (x1 <= x2)
                {
                    int oldARowArrayIndex = old.A[y];
                    int oldCRowArrayIndex = old.C[y];
                    int screenARowArrayIndex = A[y];
                    int screenCRowArrayIndex = C[y];
                    int currentMatchingLength = 0;
                    int currentMatchStartingIndex = 0;
                    Colour currentMatchingColor = AttrBlank;
                    for (int x = x1; x <= x2; x++)
                    {
                        Colour oa = old.Va[oldARowArrayIndex + x];
                        char oc = old.Vc[oldCRowArrayIndex + x];
                        Colour na = Va[screenARowArrayIndex + x];
                        char nc = Vc[screenCRowArrayIndex + x];
                        if (na == oa && nc == oc)
                        {
                            if (currentMatchingLength != 0)
                            {
                                batchPrintLines.Add(new PrintLine(y, currentMatchStartingIndex, new string(Vc, screenCRowArrayIndex + currentMatchStartingIndex, currentMatchingLength), currentMatchingColor, Colour.Background));
                                currentMatchingLength = 0;
                            }
                            continue;
                        }
                        old.Va[oldARowArrayIndex + x] = na;
                        old.Vc[oldCRowArrayIndex + x] = nc;
                        if (currentMatchingColor != na)
                        {
                            if (currentMatchingLength != 0)
                            {
                                batchPrintLines.Add(new PrintLine(y, currentMatchStartingIndex, new string(Vc, screenCRowArrayIndex + currentMatchStartingIndex, currentMatchingLength), currentMatchingColor, Colour.Background));
                                currentMatchingLength = 0;
                            }
                            currentMatchingColor = na;
                        }
                        if (currentMatchingLength++ == 0)
                        {
                            currentMatchStartingIndex = x;
                        }
                    }
                    if (currentMatchingLength != 0)
                    {
                        batchPrintLines.Add(new PrintLine(y, currentMatchStartingIndex, new string(Vc, screenCRowArrayIndex + currentMatchStartingIndex, currentMatchingLength), currentMatchingColor, Colour.Background));
                    }

                    UpdateWindow.X1[y] = Width;
                    UpdateWindow.X2[y] = 0;
                }
            }
            UpdateWindow.Y1 = Height;
            UpdateWindow.Y2 = 0;

            // Render the new cursor position, if it is being shown.
            if (CursorVisible)
            {
                // Turn on the new cursor position.
                int indexForNewCursor = C[Cy] + Cx; // This is the index to the row of characters in the screen array.
                batchPrintLines.Add(new PrintLine(Cy, Cx, Vc[indexForNewCursor].ToString(), Va[indexForNewCursor], Colour.Purple));
            }

            old.CursorVisible = CursorVisible;
            old.Cx = Cx;
            old.Cy = Cy;

            // Now emit the batched print objects to the console.
            if (batchPrintLines.Count > 0)
            {
                console.BatchPrint(batchPrintLines.ToArray());
            }
        }

        /// <summary>
        /// Refresh a spectator window.  The contents of the current screen are batch printed to the spectator console.
        /// </summary>
        public void RefreshSpectatorConsole(IConsole spectatorConsole)
        {
            List<PrintLine> batchPrintLines = new List<PrintLine>();
            spectatorConsole.Clear();

            // Loop through each row of the entire display.  It may be smaller than the full 45 rows.
            for (int y = 0; y < Height; ++y)
            {
                int scrAa = A[y];
                int scrCc = C[y];
                int fn = 0;
                int fx = 0;
                Colour currentColor = AttrBlank;
                for (int x = 0; x < Width; x++)
                {
                    Colour na = Va[scrAa + x];
                    char nc = Vc[scrCc + x];
                    if (currentColor != na)
                    {
                        if (fn != 0)
                        {
                            batchPrintLines.Add(new PrintLine(y, fx, new string(Vc, scrCc + fx, fn), currentColor, Colour.Background));
                            fn = 0;
                        }
                        currentColor = na;
                    }
                    if (fn++ == 0)
                    {
                        fx = x;
                    }
                }
                if (fn != 0)
                {
                    batchPrintLines.Add(new PrintLine(y, fx, new string(Vc, scrCc + fx, fn), currentColor, Colour.Background));
                }
            }

            if (CursorVisible)
            {
                int scrCc = C[Cy]; // This is the index to the row of characters in the screen array.
                batchPrintLines.Add(new PrintLine(Cy, Cx, Vc[scrCc + Cx].ToString(), Va[scrCc + Cx], Colour.Purple));
            }

            if (batchPrintLines.Count > 0)
                spectatorConsole.BatchPrint(batchPrintLines.ToArray());
        }

        /// <summary>
        /// Erases a number of characters on the screen
        /// </summary>
        /// <param name="row"> The row position of the first character </param>
        /// <param name="col"> The column position of the first character </param>
        /// <param name="length"> The number of characters to erase </param>
        public void Erase(int row, int col, int? length = null)
        {
            if (length == null)
            {
                length = Width;
            }

            int w = Width;
            int x1 = -1;
            int x2 = -1;
            Colour na = AttrBlank;
            char nc = CharBlank;
            Goto(row, col);
            if (col + length > w)
            {
                length = w - col;
            }
            int scrAa = A[row];
            int scrCc = C[row];
            for (int i = 0; i < length; i++, col++)
            {
                Colour oa = Va[scrAa + col];
                int oc = Vc[scrCc + col];
                if (oa == na && oc == nc)
                {
                    continue;
                }
                Va[scrAa + col] = na;
                Vc[scrCc + col] = nc;
                if (x1 < 0)
                {
                    x1 = col;
                }
                x2 = col;
            }
            if (x1 >= 0)
            {
                UpdateWindow.EncompassRowSegment(row, x1, x2);
            }
        }

        /// <summary>
        /// Prints a character at a given location
        /// </summary>
        /// <param name="attr"> The colour in which to print </param>
        /// <param name="ch"> The character to print </param>
        /// <param name="row"> The y position at which to print </param>
        /// <param name="col"> The x position at which to print </param>
        public void Print(Colour attr, char ch, int row, int col)
        {
            Goto(row, col);
            Print(attr, ch.ToString());
        }

        /// <summary>
        /// Prints a string at a given location
        /// </summary>
        /// <param name="attr"> The colour in which to print </param>
        /// <param name="str"> The string to print </param>
        /// <param name="row"> The y position at which to print the string </param>
        /// <param name="col"> The x position at which to print the string </param>
        public void Print(Colour attr, string str, int row, int col)
        {
            Goto(row, col);
            Print(attr, str);
        }

        /// <summary>
        /// Prints a string, word-wrapping it onto successive lines
        /// </summary>
        /// <param name="a"> The colour in which to print </param>
        /// <param name="str"> The string to print </param>
        public void PrintWrap(Colour a, string str)
        {
            int y = Cy;
            int x = Cx;
            string[] split = str.Split(' ');
            for (int i = 0; i < split.Length; i++)
            {
                string s = split[i];
                if (i > 0)
                {
                    s = " " + s;
                }
                if (x + s.Length > Width)
                {
                    x = 0;
                    y++;
                    if (y > 22)
                    {
                        return;
                    }
                    Erase(y, x);
                }
                foreach (char c in s)
                {
                    if (c == ' ' && x == 0)
                    {
                    }
                    else if (c == '\n')
                    {
                        x = 0;
                        y++;
                        Erase(y, x);
                    }
                    else if (c >= ' ')
                    {
                        Print(a, c, y, x);
                        x++;
                    }
                    else
                    {
                        Print(a, ' ', y, x);
                        x++;
                    }
                }
            }
        }

        /// <summary>
        /// Prints a string at a given location
        /// </summary>
        /// <param name="str"> The string to print </param>
        /// <param name="row"> The row at which to print </param>
        /// <param name="col"> The column at which to print </param>
        public void Print(string str, int row, int col)
        {
            Goto(row, col);
            Print(Colour.White, str);
        }

        /// <summary>
        /// Print a string in a specific color, erasing the rest of the line to the width of the screen.
        /// </summary>
        /// <param name="attr"> The colour in which to print </param>
        /// <param name="str"> The string to print </param>
        /// <param name="row"> The row at which to print </param>
        /// <param name="col"> The column at which to print </param>
        public void PrintLine(Colour attr, string str, int row, int col)
        {
            Erase(row, col);
            Print(attr, str);
        }

        /// <summary>
        /// Print a string in white color, erasing the rest of the line to the width of the screen.
        /// </summary>
        /// <param name="str"> The string to print </param>
        /// <param name="row"> The row at which to print </param>
        /// <param name="col"> The column at which to print </param>
        public void PrintLine(string str, int row, int col)
        {
            PrintLine(Colour.White, str, row, col);
        }

        /// <summary>
        /// Prints a string at the current cursor position.  The cursor position is moved.
        /// </summary>
        /// <param name="attr"> The colour in which to print the string </param>
        /// <param name="str"> The string to print </param>
        /// <param name="length"> The number of characters to print (-1 for all) </param>
        public void Print(Colour attr, string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return;
            }

            // Compute the length that can be printed.
            int length = str.Length;

            /// Check to see if we need to truncate the text.
            if (Cx + length >= Width)
            {
                // Truncate the text.
                length = Width - Cx;
            }
            if (length > 0)
            {
                RenderString(Cx, Cy, attr, str.Substring(0, length));
                Cx += length;
            }
        }

        /// <summary>
        /// Places a character without moving the text position
        /// </summary>
        /// <param name="attr"> The colour to use for the character </param>
        /// <param name="ch"> The character to place </param>
        /// <param name="row"> The row at which to place the character </param>
        /// <param name="col"> The column at which to place the character </param>
        public void PutChar(Colour attr, char ch, int row, int col)
        {
            if (col < 0 || col >= Width)
            {
                return;
            }
            if (row < 0 || row >= Height)
            {
                return;
            }
            if (ch == 0)
            {
                return;
            }
            RenderString(col, row, attr, ch.ToString());
        }

        /// <summary>
        /// Prints a string on the screen, without moving the cursor.  No checks are made to ensure the string fits on the string.
        /// </summary>
        /// <param name="x"> The x location to display the string </param>
        /// <param name="y"> The y location to display the string </param>
        /// <param name="n"> The number of characters to display (-1 for all) </param>
        /// <param name="a"> The colour in which to display the string </param>
        /// <param name="s"> The string to print </param>
        public void RenderString(int x, int y, Colour a, string s)
        {
            int? x1 = null;
            int? x2 = null;
            int scrAa = A[y];
            int scrCc = C[y];
            foreach (char c in s)
            {
                Colour oa = Va[scrAa + x];
                int oc = Vc[scrCc + x];
                if (oa == a && oc == c)
                {
                    x++;
                    continue;
                }
                Va[scrAa + x] = a;
                Vc[scrCc + x] = c;
                if (x1 == null)
                {
                    x1 = x;
                }
                x2 = x;
                x++;
            }
            if (x1 != null)
            {
                UpdateWindow.EncompassRowSegment(y, x1.Value, x2.Value);
            }
        }
    }
}