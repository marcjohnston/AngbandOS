// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StudyConditionalWidget : ConditionalWidgetGameConfiguration
{
    public override (string conditionalName, bool isTrue, int term)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.CanStudyBoolFunction), true, 0)
    };

    public override string[]? TrueWidgetNames => new string[] { nameof(StudyLabelWidget) };

    public override string[]? FalseWidgetNames => new string[] { nameof(NonStudyLabelWidget) };
    public override string[]? ChangeTrackerNames => new string[] { nameof(FunctionsEnum.CanStudyBoolFunction) };
}
