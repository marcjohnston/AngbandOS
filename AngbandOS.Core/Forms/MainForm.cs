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

    public void MoveCursorRelative(int row, int col)
    {
        foreach (Widget widget in Widgets) // TODO: Need a repo for IPutWidget
        {
            if (typeof(IPutWidget).IsAssignableFrom(widget.GetType()))
            {
                IPutWidget putWidget = (IPutWidget)widget;
                putWidget.MoveCursorRelative(row, col);
            }
        }
    }

    public void PutChar(ColorEnum attr, char ch, int row, int col)
    {
        foreach (Widget widget in Widgets) // TODO: Need a repo for IPutWidget
        {
            if (typeof(IPutWidget).IsAssignableFrom(widget.GetType()))
            {
                IPutWidget putWidget = (IPutWidget)widget;
                putWidget.PutChar(attr, ch, row, col);
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