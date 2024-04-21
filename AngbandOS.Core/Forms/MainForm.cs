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

    protected override string[] WidgetNames => new string[]
    {
        nameof(AfraidChangeTrackingWidget),
        nameof(ArmorClassLabelTextWidget),
        nameof(ArmorClassChangeTrackingWidget),
        nameof(BlindnessChangeTrackingWidget),
        nameof(CharacterSubclassNameStringWidget),
        nameof(ConfusedChangeTrackingWidget),
        nameof(CurrentDateLabelTextWidget),
        nameof(CurrentTimeLabelTextWidget),
        nameof(CutChangeTrackingWidget),
        nameof(DepthWidget),
        nameof(DungeonMapWidget),
        nameof(ExperienceLevelChangeTrackingWidget),
        nameof(ExperiencePointsForNextLevelChangeTrackingWidget),
        nameof(ExperiencePointsLabelWidget),
        nameof(GameDayDateWidget),
        nameof(GameTimeOfDayTimeWidget),
        nameof(GoldLabelWidget),
        nameof(GoldIntWidget),
        nameof(HealthPointsLabelWidget),
        nameof(HealthPointsMaxRangedWidget),
        nameof(HungerChangeTrackingWidget),
        nameof(ManaConditionalWidget),
        nameof(MaxHealthPointsLabelWidget),
        nameof(MaxHealthPointsWidget),
        nameof(PlayerNameWidget),
        nameof(PlayerTitleIsWinnerWidget),
        nameof(PlayerTitleIsWizardWidget),
        nameof(PlayerTitleWidget),
        nameof(PoisonedChangeTrackingWidget),
        nameof(RaceTitleWidget),
        nameof(StudyWidget),
        nameof(StunnedChangeTrackingWidget),
        nameof(TargetedMonsterRaceNameMultilineNullableStringWidget),
        nameof(TrapDetectionChangeTrackingWidget)
    };
}