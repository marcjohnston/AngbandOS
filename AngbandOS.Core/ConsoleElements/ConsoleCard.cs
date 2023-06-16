namespace AngbandOS.Core.ConsoleElements;

/// <summary>
/// Represents a card that can be rendered on the console.  Cards typically are rendered using the ConsoleGrid.  A card automatically computes the width and height of the "Print"ed
/// content so that a ConsoleGrid can wrap the cards as needed.
/// </summary>
internal class ConsoleCard : ConsoleElement
{
    private int _width;
    private int _height;
    private ConsoleChar?[][] screen = new ConsoleChar?[0][];

    public override int Width => _width;
    public override int Height => _height;
    public override void Render(SaveGame saveGame, ConsoleWindow containerWindow, ConsoleAlignment parentAlignment)
    {
        for (int rowIndex = 0; rowIndex < screen.Length; rowIndex++)
        {
            ConsoleChar?[] screenRow = screen[rowIndex];
            for (int col = 0; col < screenRow.Length; col++)
            {
                ConsoleChar? consoleChar = screenRow[col];
                if (consoleChar != null)
                {
                    ConsoleLocation consoleLocation = containerWindow.TopLeft.Offset(col, rowIndex);
                    consoleChar.Render(saveGame, consoleLocation.ToWindow(1, 1), parentAlignment);
                }
            }
        }
    }

    /// <summary>
    /// Updates the size of the screen based on the width and height without losing any of the content.  The screen is only enlargened.
    /// </summary>
    private void Reallocate(int width, int height)
    {
        // Add additional width, if needed, to the existing rows.
        if (width > _width)
        {
            for (int i = 0; i < screen.Length; i++)
            {
                Array.Resize(ref screen[i], width);
            }
            _width = width;
        }

        // Add additional rows, if needed.
        if (height > _height)
        {
            Array.Resize(ref screen, height);
            for (int i = _height; i < height; i++)
            {
                Array.Resize(ref screen[i], _width);
            }
            _height = height;
        }
    }

    /// <summary>
    /// Prints a string using a single colour at a position in the card.  Wrapping is not supported.  Any previous content printed at the same location is replaced.
    /// </summary>
    /// <param name="col">0-based column to start printing.</param>
    /// <param name="row">0-based row to print on.</param>
    /// <param name="colour"></param>
    /// <param name="text"></param>
    public void Print(int col, int row, Colour colour, string text)
    {
        if (text.Length > 0)
        {
            // Update the size of the screen.
            Reallocate(col + text.Length, row + 1);

            foreach (char c in text)
            {
                screen[row][col] = new ConsoleChar(colour, c);
                col++;
            }
        }
    }

    public ConsoleCard()
    {
        Reallocate(0, 0);
    }
}
