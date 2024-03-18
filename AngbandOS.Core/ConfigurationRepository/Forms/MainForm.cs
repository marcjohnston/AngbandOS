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
    private MainForm(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    protected override string[] WidgetNames => new string[]
    {
        nameof(AfraidWidget),
        nameof(BlindnessWidget),
        nameof(ConfusedWidget),
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
        nameof(ManaLabelWidget),
        nameof(ManaWidget),
        nameof(MaxHealthPointsLabelWidget),
        nameof(MaxHealthPointsWidget),
        nameof(MaxManaLabelWidget),
        nameof(MaxManaWidget),
        nameof(PlayerTitleIsWinnerWidget),
        nameof(PlayerTitleIsWizardWidget),
        nameof(PlayerTitleWidget),
        nameof(PoisonedWidget),
        nameof(StunnedWidget),
    };
}