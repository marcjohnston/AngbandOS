namespace AngbandOS.Core;

/// <summary>
/// Represents a window into the screen that has been modified.  This window limits how much of the double buffer screen needs to be checked.
/// </summary>
[Serializable]
internal class UpdateWindow
{
    public int Y1;
    public int Y2;
    public int[] X1;
    public int[] X2;
    private int Width { get; }
    private int Height { get; }

    public UpdateWindow(int width, int height)
    {
        Width = width;
        Height = height;
        X1 = new int[height];
        X2 = new int[height];
        Reset();
    }

    /// <summary>
    /// Resets the update window to encompass the entire window for redraw.  This means that the entire window will be updated.
    /// </summary>
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

    /// <summary>
    /// Widens the update window to accommodate a segment of grid positions from (x1 to x2) of a specific row to be marked as needing to be updated.
    /// </summary>
    /// <param name="y"></param>
    /// <param name="x1"></param>
    /// <param name="x2"></param>
    public void EncompassRowSegment(int y, int x1, int x2)
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
}
