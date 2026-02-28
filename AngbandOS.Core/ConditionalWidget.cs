// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class ConditionalWidget : Widget, IGetKey, IToJson
{
    public ConditionalWidget(Game game, ConditionalWidgetGameConfiguration conditionalWidgetGameConfiguration) : base(game)
    {
        Key = conditionalWidgetGameConfiguration.Key ?? conditionalWidgetGameConfiguration.GetType().Name;
        ProductOfSumsBoolFunctionKey = conditionalWidgetGameConfiguration.ProductOfSumsBoolFunctionKey;
        TrueWidgetNames = conditionalWidgetGameConfiguration.TrueWidgetNames;
        FalseWidgetNames = conditionalWidgetGameConfiguration.FalseWidgetNames;
        ChangeTrackerNames = conditionalWidgetGameConfiguration.ChangeTrackerNames;
    }

    /// <summary>
    /// Returns the name of the property that participates in change tracking.  This property is used to bind the <see cref="ChangeTrackers"/> property during the bind phase.
    /// </summary>
    public string[]? ChangeTrackerNames { get; } = null;

    public string Key { get; }

    public string GetKey => Key;

    public void Bind()
    {
        ChangeTrackers = Game.SingletonRepository.GetNullable<IChangeTracker>(ChangeTrackerNames);
        ProductOfSumsBoolFunction = Game.SingletonRepository.Get<ProductOfSumsConditional>(ProductOfSumsBoolFunctionKey);
        TrueWidgets = Game.SingletonRepository.GetNullable<Widget>(TrueWidgetNames);
        FalseWidgets = Game.SingletonRepository.GetNullable<Widget>(FalseWidgetNames);
    }

    public string ToJson()
    {
        ConditionalWidgetGameConfiguration conditionalWidgetGameConfiguration = new ConditionalWidgetGameConfiguration()
        {
            Key = Key,
            ProductOfSumsBoolFunctionKey = ProductOfSumsBoolFunctionKey,
            TrueWidgetNames = TrueWidgetNames,
            FalseWidgetNames = FalseWidgetNames,
            ChangeTrackerNames = ChangeTrackerNames,
        };
        return JsonSerializer.Serialize(conditionalWidgetGameConfiguration, Game.GetJsonSerializerOptions());
    }

    public ProductOfSumsConditional ProductOfSumsBoolFunction { get; private set; }
    private string ProductOfSumsBoolFunctionKey { get; }

    /// <summary>
    /// Returns the name of the widget to invalidate when the <see cref="Enabled"/> property returns true; or null, if no widget should be invalidated.  This 
    /// property is used to bind the <see cref="TrueWidgets"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    public string[]? TrueWidgetNames { get; } = null;

    /// <summary>
    /// Returns the name of the widget to invalidate when the <see cref="Enabled"/> property returns false; or null, if no widget should be invalidated.  This 
    /// property is used to bind the <see cref="FalseWidgets"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    public string[]? FalseWidgetNames { get; } = null;

    /// <summary>
    /// Returns the widget to invalidate when the <see cref="Enabled"/> property returns true.  This property is bound using the <see cref="TrueWidgetNames"/> property 
    /// during the bind phase.
    /// </summary>
    private Widget[]? TrueWidgets { get; set; }

    /// <summary>
    /// Returns the widget to invalidate when the <see cref="Enabled"/> property returns false.  This property is bound using the <see cref="FalseWidgetNames"/> property 
    /// during the bind phase.
    /// </summary>
    private Widget[]? FalseWidgets { get; set; }

    /// <summary>
    /// Evaluates the <see cref="Enabled"/> property as a Product of Sums expression and returns true or false accordingly.
    /// </summary>
    private bool EvaluateEnabledExpression
    {
        get
        {
            return ProductOfSumsBoolFunction.BoolValue;
        }
    }

    protected override void Paint() { }

    /// <summary>
    /// Update the widget on the screen, if the widget needs to be redrawn.  The widget will be redrawn, if the widget was invalidated or the derived widget returns true
    /// on the QueryRedraw method.
    /// </summary>
    public override void Update()
    {
        if (IsInvalid)
        {
            // Select the list of widgets to use based on the condition.
            Widget[]? widgets = EvaluateEnabledExpression ? TrueWidgets : FalseWidgets;

            // Check to see if there are widgets that need to be rendered.
            if (widgets != null)
            {
                // Render each of the widgets.
                foreach (Widget widget in widgets)
                {
                    widget.Invalidate();
                    widget.Update();
                }
            }
        }
    }
}
