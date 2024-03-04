// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawGoldFlaggedAction : FlaggedAction
{
    /// <summary>
    /// Returns the column position for the widget.
    /// </summary>
    public virtual int Column => 0;

    /// <summary>
    /// Returns the row position for the widget.
    /// </summary>
    public virtual int Row => 11;

    public virtual string PrefixName => "GP ";

    /// <summary>
    /// Returns the color to render the value.
    /// </summary>
    public virtual ColorEnum Color => ColorEnum.BrightGreen;

    /// <summary>
    /// Returns the color to render the value.
    /// </summary>
    public virtual ColorEnum PrefixColor => ColorEnum.White;

    /// <summary>
    /// Returns the width of the widget.
    /// </summary>
    public virtual int Width => 9;

    private RedrawGoldFlaggedAction(SaveGame saveGame) : base(saveGame) { }

    protected override void Execute()
    {
        SaveGame.Screen.Print(PrefixColor, PrefixName, Row, Column);
        string tmp = SaveGame.Gold.ToString().PadLeft(Width);
        SaveGame.Screen.Print(Color, tmp, Row, PrefixName.Length);
    }
}
