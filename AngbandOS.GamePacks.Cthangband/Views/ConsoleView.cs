// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ConsoleView : ViewGameConfiguration
{
    public override string[] WidgetNames => new string[]
    {
        nameof(AfraidRangedWidget),
        nameof(ArmorClassLabelTextWidget),
        nameof(ArmorClassIntWidget),
        nameof(BlindnessRangedWidget),
        nameof(CharacterSubclassNameStringWidget),
        nameof(ConfusedRangedWidget),
        nameof(CutRangedWidget),
        nameof(DepthStringWidget),
        nameof(DungeonMapWidget),
        nameof(ExperienceLevelConditionalWidget),
        nameof(ExperiencePointsAtMaxConditionalWidget),
        nameof(ExperiencePointsLabelTextWidget),
        nameof(GameDateLabelTextWidget),
        nameof(GameDayDateWidget),
        nameof(GameTimeLabelTextWidget),
        nameof(GameTimeOfDayTimeWidget),
        nameof(GoldLabelTextWidget),
        nameof(GoldIntWidget),
        nameof(HealthPointsLabelTextWidget),
        nameof(HealthPointsMaxRangedWidget),
        nameof(HungerRangedWidget),
        nameof(ManaConditionalWidget),
        nameof(MaxHealthPointsLabelTextWidget),
        nameof(MaxHealthPointsIntWidget),
        nameof(PlayerNameStringWidget),
        nameof(PlayerTitleConditionalWidget),
        nameof(PoisonedRangedWidget),
        nameof(RaceTitleStringWidget),
        nameof(StudyBoolWidget),
        nameof(StunnedRangedWidget),
        nameof(TrackedMonsterConditionalWidget),
        nameof(TrapDetectionConditionalWidget)
    };
}