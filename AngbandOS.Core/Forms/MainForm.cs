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
        nameof(CharacterSubclassNameChangeTrackingWidget),
        nameof(ConfusedChangeTrackingWidget),
        nameof(CutChangeTrackingWidget),
        nameof(DepthChangeTrackingWidget),
        nameof(DungeonMapChangeTrackingWidget),
        nameof(ExperienceLevelChangeTrackingWidget),
        nameof(ExperiencePointsForNextLevelChangeTrackingWidget),
        nameof(ExperiencePointsLabelTextWidget),
        nameof(GameDateLabelTextWidget),
        nameof(GameDayChangeTrackingWidget),
        nameof(GameTimeLabelTextWidget),
        nameof(GameTimeOfDayChangeTrackingWidget),
        nameof(GoldLabelTextWidget),
        nameof(GoldChangeTrackingWidget),
        nameof(HealthPointsLabelTextWidget),
        nameof(HealthPointsChangeTrackingWidget),
        nameof(HungerChangeTrackingWidget),
        nameof(ManaConditionalWidget),
        nameof(MaxHealthPointsLabelTextWidget),
        nameof(MaxHealthPointsIntWidget),
        nameof(PlayerNameChangeTrackingWidget),
        nameof(PlayerTitleConditionalWidget),
        nameof(PoisonedChangeTrackingWidget),
        nameof(RaceTitleChangeTrackingWidget),
        nameof(StudyChangeTrackingWidget),
        nameof(StunnedChangeTrackingWidget),
        nameof(TargetedMonsterRaceNameMultilineNullableStringChangeTrackingWidget),
        nameof(TrapDetectionChangeTrackingWidget)
    };
}