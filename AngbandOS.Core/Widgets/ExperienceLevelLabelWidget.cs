
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal class ExperienceLevelLabelConditionalWidget : ConditionalWidget
{
    private ExperienceLevelLabelConditionalWidget(Game game) : base(game) { } // This object is a singleton.
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(ExperienceLevelsLostFunction), true, 0)
    };
    public override string TrueWidgetName => nameof(ExperienceLevelLostLabelWidget);

    public override string FalseWidgetName => nameof(ExperienceLevelLabelWidget);
}

[Serializable]
internal class ExperienceLevelLabelWidget : TextWidget
{
    private ExperienceLevelLabelWidget(Game game) : base(game) { } // This object is a singleton.
    public override int X => 0;
    public override int Y => 5;
    public override string Text => "LEVEL";
}
