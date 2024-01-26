// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

/// <summary>
/// Represents a buffer of screen data.  This buffer is used for the screen contents and the double buffer to emit to the console.
/// </summary>
[Serializable]
internal class ScreenBuffer
{
    /// <summary>
    /// Array of color data for the entire screen.
    /// </summary>
    public readonly ColorEnum[] Va;

    /// <summary>
    /// Array of character data for the entire screen.
    /// </summary>
    public readonly char[] Vc;

    /// <summary>
    /// The x coordinate position of the cursor.
    /// </summary>
    public int Cx = 0;

    /// <summary>
    /// The y coordinate position of the cursor.
    /// </summary>
    public int Cy = 0;

   /// <summary>
    /// Whether or nt the cursor is visible.  Encapsulated using the CursorVisible property.
    /// </summary>
    public bool CursorVisible = false;

    public ScreenBuffer(int width, int height)
    {
        Va = new ColorEnum[width * height];
        Vc = new char[width * height];
    }
}