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
        public UpdateWindow UpdateWindow;

        public Colour AttrBlank;
        public char CharBlank;

        /// <summary>
        /// The height of the screen.
        /// </summary>
        public int Height;

        /// <summary>
        /// The width of the screen.
        /// </summary>
        public int Width;

        public readonly int[] A; // Represents fast character index into Va for each row.  0, 80, 160 etc ...  // Was a pointer to part of va, now an index into it // TODO: not sure if this is needed anymore
        public readonly int[] C; // Was a pointer to part of va, now an index into it
        public readonly Colour[] Va; // Array of color data for the entire screen
        public readonly char[] Vc; // Array of character data for the entire screen

        public bool TotalErase; // TODO: Needs to be deleted

        /// <summary>
        /// Whether or nt the cursor is visible.  Encapsulated using the CursorVisible property.
        /// </summary>
        private bool _cursorVisible; // TODO: Combine this into a GridCoordinate? (nullable)

        /// <summary>
        /// The x coordinate position of the cursor.
        /// </summary>
        public int Cx; // TODO: Combine this into a GridCoordinate? (nullable)

        /// <summary>
        /// The y coordinate position of the cursor.
        /// </summary>
        public int Cy; // TODO: Combine this into a GridCoordinate? (nullable)

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
        }

        public Screen(int w, int h)
        {
            Width = w;
            Height = h;

            UpdateWindow = new UpdateWindow(Height, Width);

            AttrBlank = 0;
            CharBlank = ' ';

            TotalErase = true;

            // Initialize A, C, Va and Vc.  A and C are character indexes for each row so that we do not have to multiply.
            A = new int[h];
            C = new int[h];
            Va = new Colour[h * w];
            Vc = new char[h * w];
            for (int y = 0; y < h; y++)
            {
                A[y] = w * y;
                C[y] = w * y;
            }
        }

        public void Copy(Screen f, int w, int h)
        {
            for (int y = 0; y < h; y++)
            {
                int fAa = f.A[y];
                int fCc = f.C[y];
                int sAa = A[y];
                int sCc = C[y];
                for (int x = 0; x < w; x++)
                {
                    Va[sAa++] = f.Va[fAa++];
                    Vc[sCc++] = f.Vc[fCc++];
                }
            }
            Cx = f.Cx;
            Cy = f.Cy;
            CursorVisible = f.CursorVisible;
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
   }
}