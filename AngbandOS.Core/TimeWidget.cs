﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class TimeWidget : Widget, IGetKey, IToJson
{
    public TimeWidget(Game game, TimeWidgetGameConfiguration timeWidgetGameConfiguration) : base(game)
    {
        Key = timeWidgetGameConfiguration.Key ?? timeWidgetGameConfiguration.GetType().Name;
        DateAndTimeValueName = timeWidgetGameConfiguration.DateAndTimeValueName;
        Color = timeWidgetGameConfiguration.Color;
        X = timeWidgetGameConfiguration.X;
        Y = timeWidgetGameConfiguration.Y;
        Width = timeWidgetGameConfiguration.Width;
        JustificationName = timeWidgetGameConfiguration.JustificationName;
        ChangeTrackerNames = timeWidgetGameConfiguration.ChangeTrackerNames;
    }

    public virtual string DateAndTimeValueName { get; }

    public virtual string Key { get; }
    public string GetKey => Key;

    public IDateAndTimeValue DateAndTimeValue { get; private set; }

    /// <summary>
    /// Returns the name of the property that participates in change tracking.  This property is used to bind the <see cref="ChangeTrackers"/> property during the bind phase.
    /// </summary>
    public virtual string[]? ChangeTrackerNames { get; } = null;

    /// <summary>
    /// Returns the text to be rendered for the widget.
    /// </summary>
    public virtual string Text { get; }

    /// <summary>
    /// Returns the color that the widget <see cref="Text"/> will be drawn.  Returns the color white by default.
    /// </summary>
    public virtual ColorEnum Color { get; } = ColorEnum.White;

    /// <summary>
    /// Returns the x-coordinate on the <see cref="View"/> where the widget will be drawn.
    /// </summary>
    public virtual int X { get; }

    /// <summary>
    /// Returns the y-coordinate on the <see cref="View"/> where the widget will be drawn.
    /// </summary>
    public virtual int Y { get; }

    /// <summary>
    /// Returns the width of the widget.  A width that is equal to the length of the <see cref="Text"/> property is returned by default.
    /// </summary>
    public virtual int? Width { get; } = null;

    /// <summary>
    /// Returns the <see cref="Justification"/> object to be used to justify the text within the <see cref="Width"/> of the <see cref="LabelWidget"/>.  This property is bound using
    /// the <see cref="JustificationName"/> property during the bind phase.
    /// </summary>
    protected Justification Justification { get; private set; }

    /// <summary>
    /// Returns the name of the <see cref="Justification"/> object to be used to justify the text within the <see cref="Width"/> of the <see cref="LabelWidget" />.  This property
    /// is used to bind the <see cref="Justification"/> property.  Defaults to <see cref="LeftJustification"/>.
    /// </summary>
    public virtual string JustificationName { get; } = nameof(LeftJustification);

    public void Bind()
    {
        ChangeTrackers = Game.SingletonRepository.GetNullable<IChangeTracker>(ChangeTrackerNames);
        Justification = Game.SingletonRepository.Get<Justification>(JustificationName);
        DateAndTimeValue = Game.SingletonRepository.Get<IDateAndTimeValue>(DateAndTimeValueName);
    }

    public string ToJson()
    {
        TimeWidgetGameConfiguration timeWidgetGameConfiguration = new TimeWidgetGameConfiguration()
        {
            Key = Key,
            DateAndTimeValueName = DateAndTimeValueName,
            Color = Color,
            X = X,
            Y = Y,
            Width = Width,
            JustificationName = JustificationName,
            ChangeTrackerNames = ChangeTrackerNames,
        };
        return JsonSerializer.Serialize(timeWidgetGameConfiguration, Game.GetJsonSerializerOptions());
    }

    /// <summary>
    /// Paint the widget on the screen.  No checks or resets of the validation status are or should be performed during this method.
    /// </summary>
    protected override void Paint()
    {
        string justifiedText = DateAndTimeValue.DateAndTimeValue.ToString("h:mmtt");
        justifiedText = Justification.Format(justifiedText, Width ?? justifiedText.Length);
        Game.Screen.Print(Color, justifiedText, Y, X);
    }
}
