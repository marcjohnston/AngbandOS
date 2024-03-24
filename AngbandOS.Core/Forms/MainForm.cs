// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Forms;

[Serializable]
internal class MainForm : Form
{
    private MainForm(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Draws a character in a specified color at a specific map location.  The map is not updated and the cursor is not moved.  This method is used by projectiles and animations.
    /// </summary>
    /// <param name="c"></param>
    /// <param name="a"></param>
    /// <param name="y"></param>
    /// <param name="x"></param>
    public void PutCharAtMapLocation(char c, ColorEnum a, int y, int x)
    {
        if (Game.PanelContains(y, x))
        {
            PutMapChar(c, a, y, x);
        }
    }

    private void PutMapChar(char c, ColorEnum a, int y, int x)
    {
        if (Game.InvulnerabilityTimer.Value != 0)
        {
            a = ColorEnum.White;
        }
        else if (Game.EtherealnessTimer.Value != 0)
        {
            a = ColorEnum.Black;
        }

        foreach (Widget widget in Widgets) // TODO: Need a repo for IPutWidget
        {
            if (typeof(IPutWidget).IsAssignableFrom(widget.GetType()))
            {
                IPutWidget putWidget = (IPutWidget)widget;
                putWidget.PutChar(a, c, y, x);
            }
        }
    }

    /// <summary>
    /// Moves the cursor to a specific map location and redraws the map location.
    /// </summary>
    /// <param name="y"></param>
    /// <param name="x"></param>
    public void RefreshMapLocation(int y, int x)
    {
        if (Game.PanelContains(y, x)) // TODO: This check is now done twice.
        {
            Game.MapInfo(y, x, out ColorEnum a, out char c);
            PutMapChar(c, a, y, x);
        }
    }

    /// <summary>
    /// Locate the cursor in the viewport at a specific level grid x, y coordinate.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    public void GotoMapLocation(int row, int col)
    {
        foreach (Widget widget in Widgets) // TODO: Need a repo for IPutWidget
        {
            if (typeof(IPutWidget).IsAssignableFrom(widget.GetType()))
            {
                IPutWidget putWidget = (IPutWidget)widget;
                putWidget.Goto(row, col);
            }
        }
    }

    protected override string[] WidgetNames => new string[]
    {
        nameof(AfraidWidget),
        nameof(ArmorClassLabelWidget),
        nameof(ArmorClassWidget),
        nameof(BlindnessWidget),
        nameof(CharacterSubclassNameWidget),
        nameof(ConfusedWidget),
        nameof(CurrentDateLabelWidget),
        nameof(CurrentDateWidget),
        nameof(CurrentTimeLabelWidget),
        nameof(CurrentTimeWidget),
        nameof(CutWidget),
        nameof(ExperienceLevelLabelWidget),
        nameof(ExperienceLevelLostLabelWidget),
        nameof(ExperienceLevelLostWidget),
        nameof(ExperienceLevelWidget),
        nameof(ExperiencePointsForNextLevelAtMaxWidget),
        nameof(ExperiencePointsForNextLevelLostWidget),
        nameof(ExperiencePointsForNextLevelWidget),
        nameof(ExperiencePointsLabelWidget),
        nameof(GoldLabelWidget),
        nameof(GoldWidget),
        nameof(HealthPointsLabelWidget),
        nameof(HealthPointsWidget),
        nameof(HungerWidget),
        nameof(ManaLabelWidget),
        nameof(ManaWidget),
        nameof(MainFormMapWidget),
        nameof(MaxHealthPointsLabelWidget),
        nameof(MaxHealthPointsWidget),
        nameof(MaxManaLabelWidget),
        nameof(MaxManaWidget),
        nameof(PlayerNameWidget),
        nameof(PlayerTitleIsWinnerWidget),
        nameof(PlayerTitleIsWizardWidget),
        nameof(PlayerTitleWidget),
        nameof(PoisonedWidget),
        nameof(RaceTitleWidget),
        nameof(StunnedWidget),
    };
}