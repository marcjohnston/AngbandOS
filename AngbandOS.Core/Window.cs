// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents a window (or screen) that is rendered to the UI.  This window will consist of the width and height.  A layout needs to conform to the window.
/// </summary>
[Serializable]
internal class Window
{
    /// <summary>
    /// Represents the active screen display.
    /// </summary>
    private ScreenBuffer ActiveScreen;

    /// <summary>
    /// Represents the screen that was last emitted to the console.  This acts as the double buffer.
    /// </summary>
    private ScreenBuffer OldScreen;

    /// <summary>
    /// A window that represents modified contents.
    /// </summary>
    private UpdateWindow UpdateWindow;

    private ColorEnum AttrBlank;
    private char CharBlank;

    /// <summary>
    /// Returns the height of the screen.
    /// </summary>
    public readonly int Height;

    /// <summary>
    /// Returns the width of the screen.
    /// </summary>
    public readonly int Width;

    /// <summary>
    /// Represents fast character index into the color and character array for each row.  0, 80, 160 etc
    /// </summary>
    private readonly int[] RowStartingIndexArray; 

    /// <summary>
    /// True, if a clear command was issued.  This flag forces a screen clear event to be emitted to the client and all screen contents redrawn when the UpdateScreen method runs.
    /// </summary>
    private bool TotalErase;

    /// <summary>
    /// Returns the current cursor position.
    /// </summary>
    public GridCoordinate CursorPosition => new GridCoordinate(ActiveScreen.Cx, ActiveScreen.Cy);

    [NonSerialized]
    private IConsoleViewPort _consoleViewPort;

    public Window(IConsoleViewPort consoleViewPort)
    {
        _consoleViewPort = consoleViewPort;    
        Width = _consoleViewPort.Width;
        Height = _consoleViewPort.Height;

        ActiveScreen = new ScreenBuffer(Width, Height);
        OldScreen = new ScreenBuffer(Width, Height);

        UpdateWindow = new UpdateWindow(Width, Height);

        AttrBlank = 0;
        CharBlank = ' ';

        TotalErase = true;

        // Initialize A, C, Va and Vc.  A and C are character indexes for each row so that we do not have to multiply.
        RowStartingIndexArray = new int[Height];
        for (int y = 0; y < Height; y++)
        {
            RowStartingIndexArray[y] = Width * y;
        }
    }

    /// <summary>
    /// Sets or returns whether the cursor is visible
    /// </summary>
    public bool CursorVisible
    {
        get => ActiveScreen.CursorVisible;
        set => ActiveScreen.CursorVisible = value;
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
        ActiveScreen.Cx = col;
        ActiveScreen.Cy = row;
    }

    private void Clear(ScreenBuffer buffer)
    {
        buffer.Cx = 0;
        buffer.Cy = 0;
        for (int y = 0; y < Height; y++)
        {
            int scrAa = RowStartingIndexArray[y];
            for (int x = 0; x < Width; x++)
            {
                buffer.Va[scrAa + x] = AttrBlank;
                buffer.Vc[scrAa + x] = CharBlank;
            }
        }
    }

    /// <summary>
    /// Clears the entire screen.
    /// </summary>
    public void Clear()
    {
        Clear(ActiveScreen);
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

    public ScreenBuffer Clone()
    {
        ScreenBuffer f = new ScreenBuffer(Width, Height);
        for (int y = 0; y < Height; y++)
        {
            int fAa = RowStartingIndexArray[y];
            for (int x = 0; x < Width; x++)
            {
                f.Va[fAa] = ActiveScreen.Va[fAa];
                f.Vc[fAa] = ActiveScreen.Vc[fAa];
                fAa++;
            }
        }
        f.Cx = ActiveScreen.Cx;
        f.Cy = ActiveScreen.Cy;
        f.CursorVisible = CursorVisible;
        return f;
    }

    /// <summary>
    /// Re-loads a saved screen to the GUI
    /// </summary>
    public void Restore(ScreenBuffer f)
    {
        for (int y = 0; y < Height; y++)
        {
            int fAa = RowStartingIndexArray[y];
            for (int x = 0; x < Width; x++)
            {
                ActiveScreen.Va[fAa] = f.Va[fAa];
                ActiveScreen.Vc[fAa] = f.Vc[fAa];
                fAa++;
            }
        }
        ActiveScreen.Cx = f.Cx;
        ActiveScreen.Cy = f.Cy;
        CursorVisible = f.CursorVisible;
        UpdateWindow.Reset();
    }

    /// <summary>
    /// Update the screen using a double buffer.  Only the window portion of the screen is checked.  The update window will be reverse reset so that no update would happen.
    /// </summary>
    public void UpdateScreen()
    {
        // All commands to be sent to the console will be queued into a single response.
        List<PrintLine> batchPrintLines = new List<PrintLine>();

        if (TotalErase)
        {
            // Emit a clear to the console.
            _consoleViewPort.Clear();

            // Clear out the double buffer so that all screen updates will write.
            Clear(OldScreen);

            // Reset the update window to check the entire screen.
            UpdateWindow.Reset();

            // The erase has been processed.
            TotalErase = false;
        }

        // Check to see if any updates are needed.
        if (UpdateWindow.Y1 > UpdateWindow.Y2 && CursorVisible == OldScreen.CursorVisible && ActiveScreen.Cx == OldScreen.Cx && ActiveScreen.Cy == OldScreen.Cy)
        {
            // No updates are needed.
            return;
        }

        // Check to see if the cursor position needs to be updated.
        if (OldScreen.CursorVisible && (!CursorVisible || OldScreen.Cx != ActiveScreen.Cx || OldScreen.Cy != ActiveScreen.Cy))
        {
            // Turn off the old cursor position.
            int indexForOldCursor = RowStartingIndexArray[OldScreen.Cy] + OldScreen.Cx; // This is the index to the row of characters in the screen array.
            batchPrintLines.Add(new PrintLine(OldScreen.Cy, OldScreen.Cx, OldScreen.Vc[indexForOldCursor].ToString(), OldScreen.Va[indexForOldCursor], ColorEnum.Background));
        }

        // Loop through each row of the entire "defined" display.  It may be smaller than the full 45 rows.
        for (int y = UpdateWindow.Y1; y <= UpdateWindow.Y2; ++y)
        {
            int x1 = UpdateWindow.X1[y];
            int x2 = UpdateWindow.X2[y];
            if (x1 <= x2)
            {
                int rowStartingIndex = RowStartingIndexArray[y];
                int currentMatchingLength = 0;
                int currentMatchStartingIndex = 0;
                ColorEnum currentMatchingColor = AttrBlank;
                for (int x = x1; x <= x2; x++)
                {
                    ColorEnum oa = OldScreen.Va[rowStartingIndex + x];
                    char oc = OldScreen.Vc[rowStartingIndex + x];
                    ColorEnum na = ActiveScreen.Va[rowStartingIndex + x];
                    char nc = ActiveScreen.Vc[rowStartingIndex + x];
                    if (na == oa && nc == oc)
                    {
                        if (currentMatchingLength != 0)
                        {
                            batchPrintLines.Add(new PrintLine(y, currentMatchStartingIndex, new string(ActiveScreen.Vc, rowStartingIndex + currentMatchStartingIndex, currentMatchingLength), currentMatchingColor, ColorEnum.Background));
                            currentMatchingLength = 0;
                        }
                        continue;
                    }
                    OldScreen.Va[rowStartingIndex + x] = na;
                    OldScreen.Vc[rowStartingIndex + x] = nc;
                    if (currentMatchingColor != na)
                    {
                        if (currentMatchingLength != 0)
                        {
                            batchPrintLines.Add(new PrintLine(y, currentMatchStartingIndex, new string(ActiveScreen.Vc, rowStartingIndex + currentMatchStartingIndex, currentMatchingLength), currentMatchingColor, ColorEnum.Background));
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
                    batchPrintLines.Add(new PrintLine(y, currentMatchStartingIndex, new string(ActiveScreen.Vc, rowStartingIndex + currentMatchStartingIndex, currentMatchingLength), currentMatchingColor, ColorEnum.Background));
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
            int indexForNewCursor = RowStartingIndexArray[ActiveScreen.Cy] + ActiveScreen.Cx; // This is the index to the row of characters in the screen array.
            batchPrintLines.Add(new PrintLine(ActiveScreen.Cy, ActiveScreen.Cx, ActiveScreen.Vc[indexForNewCursor].ToString(), ActiveScreen.Va[indexForNewCursor], ColorEnum.Purple));
        }

        OldScreen.CursorVisible = CursorVisible;
        OldScreen.Cx = ActiveScreen.Cx;
        OldScreen.Cy = ActiveScreen.Cy;

        // Now emit the batched print objects to the console.
        if (batchPrintLines.Count > 0)
        {
            _consoleViewPort.BatchPrint(batchPrintLines.ToArray());
        }
    }

    /// <summary>
    /// Refresh a spectator window.  The contents of the current screen are batch printed to the spectator console.
    /// </summary>
    public void RefreshSpectatorConsole(IViewPort spectatorConsole)
    {
        List<PrintLine> batchPrintLines = new List<PrintLine>();
        spectatorConsole.Clear();

        // Loop through each row of the entire display.  It may be smaller than the full 45 rows.
        for (int y = 0; y < Height; ++y)
        {
            int scrAa = RowStartingIndexArray[y];
            int fn = 0;
            int fx = 0;
            ColorEnum currentColor = AttrBlank;
            for (int x = 0; x < Width; x++)
            {
                ColorEnum na = ActiveScreen.Va[scrAa + x];
                char nc = ActiveScreen.Vc[scrAa + x];
                if (currentColor != na)
                {
                    if (fn != 0)
                    {
                        batchPrintLines.Add(new PrintLine(y, fx, new string(ActiveScreen.Vc, scrAa + fx, fn), currentColor, ColorEnum.Background));
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
                batchPrintLines.Add(new PrintLine(y, fx, new string(ActiveScreen.Vc, scrAa + fx, fn), currentColor, ColorEnum.Background));
            }
        }

        if (CursorVisible)
        {
            int scrCc = RowStartingIndexArray[ActiveScreen.Cy]; // This is the index to the row of characters in the screen array.
            batchPrintLines.Add(new PrintLine(ActiveScreen.Cy, ActiveScreen.Cx, ActiveScreen.Vc[scrCc + ActiveScreen.Cx].ToString(), ActiveScreen.Va[scrCc + ActiveScreen.Cx], ColorEnum.Purple));
        }

        if (batchPrintLines.Count > 0)
            spectatorConsole.BatchPrint(batchPrintLines.ToArray());
    }

    /// <summary>
    /// Erases a number of characters on the screen
    /// </summary>
    /// <param name="row"> The row position of the first character </param>
    /// <param name="col"> The column position of the first character </param>
    /// <param name="length"> The number of characters to erase or null, to erase the full width.</param>
    public void Erase(int row, int col, int? length = null)
    {
        if (length == null)
        {
            length = Width;
        }

        int w = Width;
        int x1 = -1;
        int x2 = -1;
        ColorEnum na = AttrBlank;
        char nc = CharBlank;
        Goto(row, col);
        if (col + length > w)
        {
            length = w - col;
        }
        int scrAa = RowStartingIndexArray[row];
        for (int i = 0; i < length; i++, col++)
        {
            ColorEnum oa = ActiveScreen.Va[scrAa + col];
            int oc = ActiveScreen.Vc[scrAa + col];
            if (oa == na && oc == nc)
            {
                continue;
            }
            ActiveScreen.Va[scrAa + col] = na;
            ActiveScreen.Vc[scrAa + col] = nc;
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
    /// Moves the cursor to the specific location and prints a character at that location in the specified color.
    /// </summary>
    /// <param name="attr"> The color in which to print </param>
    /// <param name="ch"> The character to print </param>
    /// <param name="row"> The y position at which to print </param>
    /// <param name="col"> The x position at which to print </param>
    public void Print(ColorEnum attr, char ch, int row, int col)
    {
        Goto(row, col);
        Print(attr, ch.ToString());
    }

    /// <summary>
    /// Prints a string at a given location
    /// </summary>
    /// <param name="attr"> The color in which to print </param>
    /// <param name="str"> The string to print </param>
    /// <param name="row"> The y position at which to print the string </param>
    /// <param name="col"> The x position at which to print the string </param>
    public void Print(ColorEnum attr, string str, int row, int col)
    {
        Goto(row, col);
        Print(attr, str);
    }

    /// <summary>
    /// Prints a string, word-wrapping it onto successive lines
    /// </summary>
    /// <param name="a"> The color in which to print </param>
    /// <param name="str"> The string to print </param>
    public void PrintWrap(ColorEnum a, string str)
    {
        int y = ActiveScreen.Cy;
        int x = ActiveScreen.Cx;
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
    /// Prints a string in white at a specified location.
    /// </summary>
    /// <param name="str"> The string to print </param>
    /// <param name="row"> The row at which to print </param>
    /// <param name="col"> The column at which to print </param>
    public void Print(string str, int row, int col)
    {
        Goto(row, col);
        Print(ColorEnum.White, str);
    }

    /// <summary>
    /// Print a string in a specific color, erasing the rest of the line to the width of the screen.
    /// </summary>
    /// <param name="attr"> The color in which to print </param>
    /// <param name="str"> The string to print </param>
    /// <param name="row"> The row at which to print </param>
    /// <param name="col"> The column at which to print </param>
    public void PrintLine(ColorEnum attr, string str, int row, int col)
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
        PrintLine(ColorEnum.White, str, row, col);
    }

    /// <summary>
    /// Prints a string at the current cursor position.  The cursor position is moved.
    /// </summary>
    /// <param name="attr"> The color in which to print the string </param>
    /// <param name="str"> The string to print </param>
    /// <param name="length"> The number of characters to print (-1 for all) </param>
    public void Print(ColorEnum attr, string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return;
        }

        // Compute the length that can be printed.
        int length = str.Length;

        /// Check to see if we need to truncate the text.
        if (ActiveScreen.Cx + length >= Width)
        {
            // Truncate the text.
            length = Width - ActiveScreen.Cx;
        }
        if (length > 0)
        {
            RenderString(ActiveScreen.Cx, ActiveScreen.Cy, attr, str.Substring(0, length));
            ActiveScreen.Cx += length;
        }
    }

    /// <summary>
    /// Print a character in a specified color at a specified location without moving the curosr.  The location is checked to ensure it is on the screen.
    /// </summary>
    /// <param name="attr"> The color to use for the character </param>
    /// <param name="ch"> The character to place </param>
    /// <param name="row"> The row at which to place the character </param>
    /// <param name="col"> The column at which to place the character </param>
    public void PutChar(ColorEnum attr, char ch, int row, int col)
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
    /// Prints a string on the screen in a specified color, without moving the cursor.  No checks are made to ensure the string fits on the string.
    /// </summary>
    /// <param name="x"> The x location to display the string </param>
    /// <param name="y"> The y location to display the string </param>
    /// <param name="n"> The number of characters to display (-1 for all) </param>
    /// <param name="a"> The color in which to display the string </param>
    /// <param name="s"> The string to print </param>
    private void RenderString(int x, int y, ColorEnum a, string s)
    {
        int? x1 = null;
        int? x2 = null;
        int scrAa = RowStartingIndexArray[y];
        foreach (char c in s)
        {
            ColorEnum oa = ActiveScreen.Va[scrAa + x];
            int oc = ActiveScreen.Vc[scrAa + x];
            if (oa == a && oc == c)
            {
                x++;
                continue;
            }
            ActiveScreen.Va[scrAa + x] = a;
            ActiveScreen.Vc[scrAa + x] = c;
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