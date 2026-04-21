// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents a window into the screen that has been modified.  This window limits how much of the double buffer screen needs to be checked.
/// </summary>
[Serializable]
internal class UpdateWindow : IGameSerialize
{
    #region State Data
    public int Y1;
    public int Y2;
    public int[] X1;
    public int[] X2;
    private int Width { get; }
    private int Height { get; }
    #endregion

    public DictionaryGameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(Y1), saveGameState.CreateGameStateBag(Y1)),
            (nameof(Y2), saveGameState.CreateGameStateBag(Y2)),
            (nameof(X1), saveGameState.CreateGameStateBag(X1)),
            (nameof(X2), saveGameState.CreateGameStateBag(X2)),
            (nameof(Width), saveGameState.CreateGameStateBag(Width)),
            (nameof(Height), saveGameState.CreateGameStateBag(Height))
        );
    }

    public UpdateWindow(Game game, RestoreGameState restoreGameState)
    {
        Y1 = restoreGameState.GetInt(nameof(Y1));
        Y2 = restoreGameState.GetInt(nameof(Y2));
        X1 = restoreGameState.GetInts(nameof(X1));
        X2 = restoreGameState.GetInts(nameof(X2));
        Width = restoreGameState.GetInt(nameof(Width));
        Height = restoreGameState.GetInt(nameof(Height));
    }

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
