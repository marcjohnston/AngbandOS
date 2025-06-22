// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TrackedMonsterRaceNameTextWidget : TextWidgetGameConfiguration
{
    public override int X => 0;
    public override int Y => 29;

    /// <summary>
    /// Returns a height of 3 because the monster race name will only be given 3 screen lines of height.
    /// </summary>
    public override int Height => 3;

    public override int Width => 12;
    /// <summary>
    /// Returns a bottom alignment to vertically align the monster name to the bottom.
    /// </summary>
    public override string AlignmentName => nameof(AlignmentsEnum.BottomAlignment);

    /// <summary>
    /// Returns a center justication to horizontally justify the monster name in the center.
    /// </summary>
    public override string JustificationName => nameof(JustificationsEnum.CenterJustification);

    /// <summary>
    /// Returns the <see cref="TrackedMonsterRaceNameNullableStringsFunction"/> function to render a multiline version of the monster race name.
    /// </summary>
    public override string NullableStringsValueName => nameof(FunctionsEnum.TrackedMonsterRaceNameTextFunction);
}
