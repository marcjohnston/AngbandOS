namespace AngbandOS.Core
{
    /// <summary>
    /// Represents a window into the screen that has been modified.  This window limits how much of the double buffer screen needs to be checked.
    /// </summary>
    [Serializable]
    internal class UpdateWindow
    {
        private int Y1;
        private int Y2;
        private int[] X1;
        private int[] X2;
        private readonly int Width;
        private readonly int Height;

        public UpdateWindow(int h, int w)
        {
            Width = w;
            Height = h;
            X1 = new int[h];
            X2 = new int[h];
            Reset();
        }

        /// <summary>
        /// Resets the window to full screen.  This means that the entire window will be updated.
        /// </summary>
        /// <param name="h"></param>
        /// <param name="w"></param>
        public void Reset()
        {
            for (int y = 0; y < Height; y++)
            {
                X1[y] = 0;
                X2[y] = Width - 1;
            }
            Y1 = 0;
            Y2 = Height - 1;
        }

        public void EncompassRow(int y, int x1, int x2)
        {
            if (y < Y1)
            {
                Y1 = y;
            }
            if (y > Y2)
            {
                Y2 = y;
            }
            if (x1 < X1[y])
            {
                X1[y] = x1;
            }
            if (x2 > X2[y])
            {
                X2[y] = x2;
            }
        }

        /// <summary>
        /// Update the screen using a double buffer.  Only the window portion of the screen is checked.  The update window will be reverse reset so that no update would happen.
        /// </summary>
        public void UpdateScreen(Screen Screen, Screen Old, IConsole console)
        {
            List<PrintLine> batchPrintLines = new List<PrintLine>();
            int y;

            // Check to see if any updates are needed.
            if (Y1 > Y2 && Screen.CursorVisible == Old.CursorVisible && Screen.Cx == Old.Cx && Screen.Cy == Old.Cy && !Screen.TotalErase)
            {
                // No updates are needed.
                return;
            }

            if (Screen.TotalErase)
            {
                // Clear the "old" screen 
                console.Clear();
                Old.CursorVisible = false;
                Old.Cx = 0;
                Old.Cy = 0;

                // For each row
                for (y = 0; y < Screen.Height; y++)
                {
                    // aa and cc point to the same index reference into Va and Vc.
                    int aa = Old.A[y];
                    int cc = Old.C[y];
                    for (int x = 0; x < Screen.Width; x++)
                    {
                        Old.Va[aa++] = Screen.AttrBlank; // Background color
                        Old.Vc[cc++] = Screen.CharBlank; // Space
                    }
                }
                // Reset the size of the display to be full height.
                Y1 = 0;
                Y2 = Screen.Height - 1;

                // Reset the width of the display for each row to be full width.
                for (y = 0; y < Screen.Height; y++)
                {
                    X1[y] = 0;
                    X2[y] = Screen.Width - 1;
                }
                Screen.TotalErase = false;
            }
 //           if (Screen.Cu || !Screen.CursorVisible)
            {
                int scrCc = Old.C[Old.Cy]; // This is the index to the row of characters in the screen array.
                batchPrintLines.Add(new PrintLine(Old.Cy, Old.Cx, Old.Vc[scrCc + Old.Cx].ToString(), Old.Va[scrCc + Old.Cx], Colour.Background));
            }

            // Loop through each row of the entire "defined" display.  It may be smaller than the full 45 rows.
            for (y = Y1; y <= Y2; ++y)
            {
                int x1 = X1[y];
                int x2 = X2[y];
                if (x1 <= x2)
                {
                    int oldAa = Old.A[y];
                    int oldCc = Old.C[y];
                    int scrAa = Screen.A[y];
                    int scrCc = Screen.C[y];
                    int fn = 0;
                    int fx = 0;
                    Colour fa = Screen.AttrBlank;
                    for (int x = x1; x <= x2; x++)
                    {
                        Colour oa = Old.Va[oldAa + x];
                        char oc = Old.Vc[oldCc + x];
                        Colour na = Screen.Va[scrAa + x];
                        char nc = Screen.Vc[scrCc + x];
                        if (na == oa && nc == oc)
                        {
                            if (fn != 0)
                            {
                                batchPrintLines.Add(new PrintLine(y, fx, new string(Screen.Vc, scrCc + fx, fn), fa, Colour.Background));
                                fn = 0;
                            }
                            continue;
                        }
                        Old.Va[oldAa + x] = na;
                        Old.Vc[oldCc + x] = nc;
                        if (fa != na)
                        {
                            if (fn != 0)
                            {
                                batchPrintLines.Add(new PrintLine(y, fx, new string(Screen.Vc, scrCc + fx, fn), fa, Colour.Background));
                                fn = 0;
                            }
                            fa = na;
                        }
                        if (fn++ == 0)
                        {
                            fx = x;
                        }
                    }
                    if (fn != 0)
                    {
                        batchPrintLines.Add(new PrintLine(y, fx, new string(Screen.Vc, scrCc + fx, fn), fa, Colour.Background));
                    }

                    X1[y] = Screen.Width;
                    X2[y] = 0;
                }
            }
            Y1 = Screen.Height;
            Y2 = 0;

            //if (Screen.Cu)
            //{
            //    int scrCc = Old.C[Old.Cy]; // This is the index to the row of characters in the screen array.
            //    batchPrintLines.Add(new PrintLine(Old.Cy, Old.Cx, Old.Vc[scrCc + Old.Cx].ToString(), Old.Va[scrCc + Old.Cx], Colour.Background));
            //}
             if (Screen.CursorVisible)
            //{
            //    int scrCc = Old.C[Old.Cy]; // This is the index to the row of characters in the screen array.
            //    batchPrintLines.Add(new PrintLine(Old.Cy, Old.Cx, Old.Vc[scrCc + Old.Cx].ToString(), Old.Va[scrCc + Old.Cx], Colour.Background));
            //}
            //else
            {
                //int scrCc = Old.C[Old.Cy]; // This is the index to the row of characters in the screen array.
                //batchPrintLines.Add(new PrintLine(Old.Cy, Old.Cx, Old.Vc[scrCc + Old.Cx].ToString(), Old.Va[scrCc + Old.Cx], Colour.Background));
                int scrCc = Screen.C[Screen.Cy]; // This is the index to the row of characters in the screen array.
                batchPrintLines.Add(new PrintLine(Screen.Cy, Screen.Cx, Screen.Vc[scrCc + Screen.Cx].ToString(), Screen.Va[scrCc + Screen.Cx], Colour.Purple));
            }
            Old.CursorVisible = Screen.CursorVisible;
            Old.Cx = Screen.Cx;
            Old.Cy = Screen.Cy;

            // Now emit the batched print objects to the console.
            if (batchPrintLines.Count > 0)
            {
                console.BatchPrint(batchPrintLines.ToArray());
            }
        }
    }
}
