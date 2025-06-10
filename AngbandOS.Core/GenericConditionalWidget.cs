// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class GenericConditionalWidget : ConditionalWidget
{
    public GenericConditionalWidget(Game game, ConditionalWidgetGameConfiguration conditionalWidgetGameConfiguration) : base(game)
    {
        Key = conditionalWidgetGameConfiguration.Key ?? conditionalWidgetGameConfiguration.GetType().Name;
        EnabledNames = conditionalWidgetGameConfiguration.EnabledNames;
        TrueWidgetNames = conditionalWidgetGameConfiguration.TrueWidgetNames;
        FalseWidgetNames = conditionalWidgetGameConfiguration.FalseWidgetNames;
        ChangeTrackerNames = conditionalWidgetGameConfiguration.ChangeTrackerNames;
    }

    /// <summary>
    /// Returns an array of the names of the conditionals that need to be met for the widget to rendered; or null, if there are no conditions.  All conditions must return true for 
    /// the widget to be enabled.  This property is bound used to bind the Enabled property during the binding phase.  The conditions are a boolean expression in the form of a product of sums (POS)
    /// that determine if the widget is enabled when the result matches the <see cref="valueConditionalMustBe"/> parameter.  The <see cref="term"/> parameter is used to determine
    /// the conditions that make up a term.  All conditions with the same term value are considered to belong to the same term (sum).  Use Gaussian Elimination to convert existing
    /// boolean expressions into POS format.
    /// </summary>
    protected override (string conditionalName, bool isTrue, int term)[] EnabledNames { get; }

    /// <summary>
    /// Returns the name of the widget to invalidate when the <see cref="Enabled"/> property returns true; or null, if no widget should be invalidated.  This 
    /// property is used to bind the <see cref="TrueWidgets"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    public override string[]? TrueWidgetNames { get; } = null;

    /// <summary>
    /// Returns the name of the widget to invalidate when the <see cref="Enabled"/> property returns false; or null, if no widget should be invalidated.  This 
    /// property is used to bind the <see cref="FalseWidgets"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    public override string[]? FalseWidgetNames { get; } = null;

    /// <summary>
    /// Returns the name of the property that participates in change tracking.  This property is used to bind the <see cref="ChangeTrackers"/> property during the bind phase.
    /// </summary>
    public override string[]? ChangeTrackerNames { get; } = null;
    public override string Key { get; }
}
