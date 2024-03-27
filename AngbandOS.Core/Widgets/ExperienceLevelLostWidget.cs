// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal class ExperienceLevelLostWidget : IntWidget
{
    private ExperienceLevelLostWidget(Game game) : base(game) { } // This object is a singleton.
    public override int X => 6;
    public override int Y => 5;
    public override int Width => 6;
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string IntChangeTrackingName => nameof(ExperienceLevelIntProperty);
    public override string? JustificationName => nameof(RightJustification);
    public override (string, bool)[]? EnabledNames => new (string, bool)[]
    {
        (nameof(MaxLevelAttainedFunction), false)
    };
}
