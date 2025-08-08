// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class IntWidget : Widget, IGetKey, IToJson
{
    public IntWidget(Game game, IntWidgetGameConfiguration intWidgetGameConfiguration) : base(game)
    {
        Key = intWidgetGameConfiguration.Key ?? intWidgetGameConfiguration.GetType().Name;
        IntValueName = intWidgetGameConfiguration.IntValueName;
        Color = intWidgetGameConfiguration.Color;
        X = intWidgetGameConfiguration.X;
        Y = intWidgetGameConfiguration.Y;
        Width = intWidgetGameConfiguration.Width;
        JustificationName = intWidgetGameConfiguration.JustificationName;
        ChangeTrackerNames = intWidgetGameConfiguration.ChangeTrackerNames;
    }
    public string Key { get; }

    public string GetKey => Key;

    public string IntValueName { get; }
    public IIntValue IntValue { get; private set; }

    /// <summary>
    /// Returns the color that the widget <see cref="Text"/> will be drawn.  Returns the color white by default.
    /// </summary>
    public ColorEnum Color { get; } = ColorEnum.White;

    /// <summary>
    /// Returns the x-coordinate on the <see cref="View"/> where the widget will be drawn.
    /// </summary>
    public int X { get; }

    /// <summary>
    /// Returns the y-coordinate on the <see cref="View"/> where the widget will be drawn.
    /// </summary>
    public int Y { get; }

    /// <summary>
    /// Returns the width of the widget.  A width that is equal to the length of the <see cref="Text"/> property is returned by default.
    /// </summary>
    public int? Width { get; } = null;

    /// <summary>
    /// Returns the <see cref="Justification"/> object to be used to justify the text within the <see cref="Width"/> of the <see cref="LabelWidget"/>.  This property is bound using
    /// the <see cref="JustificationName"/> property during the bind phase.
    /// </summary>
    private Justification Justification { get; set; }

    /// <summary>
    /// Returns the name of the <see cref="Justification"/> object to be used to justify the text within the <see cref="Width"/> of the <see cref="LabelWidget" />.  This property
    /// is used to bind the <see cref="Justification"/> property.  Defaults to <see cref="LeftJustification"/>.
    /// </summary>
    public string JustificationName { get; } = nameof(LeftJustification);

    /// <summary>
    /// Returns the name of the property that participates in change tracking.  This property is used to bind the <see cref="ChangeTrackers"/> property during the bind phase.
    /// </summary>
    public string[]? ChangeTrackerNames { get; } = null;

    public void Bind()
    {
        ChangeTrackers = Game.SingletonRepository.GetNullable<IChangeTracker>(ChangeTrackerNames);
        Justification = Game.SingletonRepository.Get<Justification>(JustificationName);
        IntValue = Game.SingletonRepository.Get<IIntValue>(IntValueName);
    }
    public string ToJson()
    {
        IntWidgetGameConfiguration intWidgetGameConfiguration = new IntWidgetGameConfiguration()
        {
            Key = Key,
            IntValueName = IntValueName,
            Color = Color,
            X = X,
            Y = Y,
            Width = Width,
            JustificationName = JustificationName,
            ChangeTrackerNames = ChangeTrackerNames,
        };
        return JsonSerializer.Serialize(intWidgetGameConfiguration, Game.GetJsonSerializerOptions());
    }   

    /// <summary>
    /// Paint the widget on the screen.  No checks or resets of the validation status are or should be performed during this method.
    /// </summary>
    protected override void Paint()
    {
        string justifiedText = IntValue.IntValue.ToString();
        justifiedText = Justification.Format(justifiedText, Width ?? justifiedText.Length);
        Game.Screen.Print(Color, justifiedText, Y, X);
    }
}
