// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Configuration;
using System.Drawing;
using System.Text.Json;

namespace AngbandOS.Core;

[Serializable]
internal abstract class ConditionalWidget : Widget
{
    protected ConditionalWidget(Game game) : base(game) { }

    /// <summary>
    /// Returns an array of conditionals that need to be met for the widget to rendered; or null, if there are no conditions.  All conditions must return true for the widget
    /// to be enabled.  This property is bound from the EnabledNames property during the binding phase.  The conditions are a boolean expression in the form of a product of sums (POS)
    /// that determine if the widget is enabled when the result matches the <see cref="valueConditionalMustBe"/> parameter.  The <see cref="term"/> parameter is used to determine
    /// the conditions that make up a term.  All conditions with the same term value are considered to belong to the same term (sum).  Use Gaussian Elimination to convert existing
    /// boolean expressions into POS format.
    /// </summary>
    protected (IBoolValue conditional, bool valueConditionalMustBe, int term)[] Enabled { get; private set; }

    /// <summary>
    /// Returns an array of the names of the conditionals that need to be met for the widget to rendered; or null, if there are no conditions.  All conditions must return true for 
    /// the widget to be enabled.  This property is bound used to bind the Enabled property during the binding phase.  The conditions are a boolean expression in the form of a product of sums (POS)
    /// that determine if the widget is enabled when the result matches the <see cref="valueConditionalMustBe"/> parameter.  The <see cref="term"/> parameter is used to determine
    /// the conditions that make up a term.  All conditions with the same term value are considered to belong to the same term (sum).  Use Gaussian Elimination to convert existing
    /// boolean expressions into POS format.
    /// </summary>
    protected abstract (string conditionalName, bool isTrue, int term)[] EnabledNames { get; }

    /// <summary>
    /// Returns the name of the widget to invalidate when the <see cref="Enabled"/> property returns true; or null, if no widget should be invalidated.  This 
    /// property is used to bind the <see cref="TrueWidgets"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    public virtual string[]? TrueWidgetNames => null;

    /// <summary>
    /// Returns the name of the widget to invalidate when the <see cref="Enabled"/> property returns false; or null, if no widget should be invalidated.  This 
    /// property is used to bind the <see cref="FalseWidgets"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    public virtual string[]? FalseWidgetNames => null;

    /// <summary>
    /// Returns the widget to invalidate when the <see cref="Enabled"/> property returns true.  This property is bound using the <see cref="TrueWidgetNames"/> property 
    /// during the bind phase.
    /// </summary>
    protected Widget[]? TrueWidgets { get; private set; }

    /// <summary>
    /// Returns the widget to invalidate when the <see cref="Enabled"/> property returns false.  This property is bound using the <see cref="FalseWidgetNames"/> property 
    /// during the bind phase.
    /// </summary>
    protected Widget[]? FalseWidgets { get; private set; }

    public override void Bind()
    {
        List<(IBoolValue, bool, int)> conditionalList = new();
        foreach ((string enabledName, bool isTrue, int term) in EnabledNames)
        {
            IBoolValue boolValue = Game.SingletonRepository.Get<IBoolValue>(enabledName);
            conditionalList.Add((boolValue, isTrue, term));
        }
        Enabled = conditionalList.ToArray();
        TrueWidgets = Game.SingletonRepository.GetNullable<Widget>(TrueWidgetNames);
        FalseWidgets = Game.SingletonRepository.GetNullable<Widget>(FalseWidgetNames);
    }

    /// <summary>
    /// Evaluates the <see cref="Enabled"/> property as a Product of Sums expression and returns true or false accordingly.
    /// </summary>
    protected bool EvaluateEnabledExpression
    {
        get
        {
            // Check to see if the widget is enabled.  Evaluate the product of sums.
            Dictionary<int, bool> terms = new Dictionary<int, bool>();
            foreach ((IBoolValue condition, bool isTrue, int term) in Enabled)
            {
                if (!terms.ContainsKey(term))
                {
                    bool conditionIsTrue = condition.BoolValue;
                    terms.Add(term, conditionIsTrue);
                }
                else if (terms[term] == false) // Short circuit evaluation
                {
                    bool conditionIsTrue = condition.BoolValue;
                    terms[term] |= conditionIsTrue;
                }
            }
            if (terms.Any(termAndResult => !termAndResult.Value))
            {
                return false;
            }
            return true;
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
    public override string ToJson()
    {
        ConditionalWidgetGameConfiguration conditionalWidgetGameConfiguration = new ConditionalWidgetGameConfiguration()
        {
            Key = Key,
            EnabledNames = EnabledNames,
            TrueWidgetNames = TrueWidgetNames,
            FalseWidgetNames = FalseWidgetNames,
            ChangeTrackerNames = ChangeTrackerNames,
        };
        return JsonSerializer.Serialize(conditionalWidgetGameConfiguration, Game.GetJsonSerializerOptions());
    }
}
