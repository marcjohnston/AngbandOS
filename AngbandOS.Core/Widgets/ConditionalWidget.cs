// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

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
    protected new (IConditional conditional, bool valueConditionalMustBe, int term)[] Enabled { get; private set; }

    /// <summary>
    /// Returns an array of the names of the conditionals that need to be met for the widget to rendered; or null, if there are no conditions.  All conditions must return true for 
    /// the widget to be enabled.  This property is bound used to bind the Enabled property during the binding phase.  The conditions are a boolean expression in the form of a product of sums (POS)
    /// that determine if the widget is enabled when the result matches the <see cref="valueConditionalMustBe"/> parameter.  The <see cref="term"/> parameter is used to determine
    /// the conditions that make up a term.  All conditions with the same term value are considered to belong to the same term (sum).  Use Gaussian Elimination to convert existing
    /// boolean expressions into POS format.
    /// </summary>
    public new abstract (string conditionalName, bool isTrue, int term)[] EnabledNames { get; }

    /// <summary>
    /// Returns the name of the widget to invalidate when the <see cref="Enabled"/> property returns true; or null, if no widget should be invalidated.  This 
    /// property is used to bind the <see cref="TrueWidget"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    public virtual string? TrueWidgetName => null;

    /// <summary>
    /// Returns the name of the widget to invalidate when the <see cref="Enabled"/> property returns false; or null, if no widget should be invalidated.  This 
    /// property is used to bind the <see cref="FalseWidget"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    public virtual string? FalseWidgetName => null;

    /// <summary>
    /// Returns the widget to invalidate when the <see cref="Enabled"/> property returns true.  This property is bound using the <see cref="TrueWidgetName"/> property 
    /// during the bind phase.
    /// </summary>
    protected Widget? TrueWidget { get; private set; }

    /// <summary>
    /// Returns the widget to invalidate when the <see cref="Enabled"/> property returns false.  This property is bound using the <see cref="FalseWidgetName"/> property 
    /// during the bind phase.
    /// </summary>
    protected Widget? FalseWidget { get; private set; }

    public override void Bind()
    {
        List<(IConditional, bool, int)> conditionalList = new();
        foreach ((string enabledName, bool isTrue, int term) in EnabledNames)
        {
            Property? property = Game.SingletonRepository.Properties.TryGet(enabledName);
            if (property != null)
            {
                conditionalList.Add(((IConditional)property, isTrue, term));
            }
            else
            {
                Function? function = Game.SingletonRepository.Functions.TryGet(enabledName);
                if (function == null)
                {
                    throw new Exception($"The {enabledName} enabled dependency cannot be found as a {nameof(Property)} or {nameof(Function)}.");
                }
                conditionalList.Add(((IConditional)function, isTrue, term));
            }
        }
        Enabled = conditionalList.ToArray();

        TrueWidget = TrueWidgetName == null ? null : Game.SingletonRepository.Widgets.Get(TrueWidgetName);
        FalseWidget = FalseWidgetName == null ? null : Game.SingletonRepository.Widgets.Get(FalseWidgetName);
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
            foreach ((IConditional condition, bool isTrue, int term) in Enabled)
            {
                if (!terms.ContainsKey(term))
                {
                    bool conditionIsTrue = condition.IsTrue;
                    terms.Add(term, conditionIsTrue);
                }
                else if (terms[term] == false) // Short circuit evaluation
                {
                    bool conditionIsTrue = condition.IsTrue;
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
            if (EvaluateEnabledExpression)
            {
                if (TrueWidget != null)
                {
                    TrueWidget.Invalidate();
                    TrueWidget.Update();
                }
            }
            else
            {
                if (FalseWidget != null)
                {
                    FalseWidget.Invalidate();
                    FalseWidget.Update();
                }
            }
        }
    }
}
