// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StudyBoolWidget : BoolWidgetGameConfiguration
{
    public override int X => 60;
    public override int Y => 44;
    public override int? Width => 5;
    public override string BoolValueName => nameof(FunctionsEnum.CanStudyFunction);
    public override string TrueValue => "Study";
    public override string FalseValue => "";
    public override string[]? ChangeTrackerNames => new string[] { nameof(FunctionsEnum.CanStudyFunction) };
}
