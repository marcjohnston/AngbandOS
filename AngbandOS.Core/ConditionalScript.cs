// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents a script that evaluates an <see cref="IBoolValue"/> and runs a script depending on the result.
/// </summary>
[Serializable]
internal class ConditionalScript : IGetKey, IScript
{
    protected readonly Game Game;
    public ConditionalScript(Game game, ConditionalScriptGameConfiguration conditionalScriptGameConfiguration)
    {
        Game = game;
        Key = conditionalScriptGameConfiguration.Key ?? conditionalScriptGameConfiguration.GetType().Name;
        EnabledNames = conditionalScriptGameConfiguration.EnabledNames;
        TrueScriptBindingKeys = conditionalScriptGameConfiguration.TrueScriptBindingKeys;
        FalseScriptBindingKeys = conditionalScriptGameConfiguration.FalseScriptBindingKeys;
    }
    /// <summary>
    /// Returns an array of conditionals that need to be met for the widget to rendered; or null, if there are no conditions.  All conditions must return true for the widget
    /// to be enabled.  This property is bound from the EnabledNames property during the binding phase.  The conditions are a boolean expression in the form of a product of sums (POS)
    /// that determine if the widget is enabled when the result matches the <see cref="valueConditionalMustBe"/> parameter.  The <see cref="productOfSumsTerm"/> parameter is used to determine
    /// the conditions that make up a term using a Product-Of-Sums formula.  All conditions with the same term value are considered to belong to the same term (sum).  Use Gaussian Elimination to convert existing
    /// boolean expressions into POS format.
    /// </summary>
    protected (IBoolValue conditional, bool valueConditionalMustBe, int productOfSumsTerm)[] Enabled { get; private set; }

    /// <summary>
    /// Returns an array of the names of the conditionals that need to be met for the widget to rendered; or null, if there are no conditions.  All conditions must return true for 
    /// the widget to be enabled.  This property is bound used to bind the Enabled property during the binding phase.  The conditions are a boolean expression in the form of a product of sums (POS)
    /// that determine if the widget is enabled when the result matches the <see cref="valueConditionalMustBe"/> parameter.  The <see cref="term"/> parameter is used to determine
    /// the conditions that make up a term.  All conditions with the same term value are considered to belong to the same term (sum).  Use Gaussian Elimination to convert existing
    /// boolean expressions into POS format.
    /// </summary>
    protected virtual (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames { get; }

    /// <summary>
    /// Returns the name of the widget to invalidate when the <see cref="Enabled"/> property returns true; or null, if no widget should be invalidated.  This 
    /// property is used to bind the <see cref="TrueWidgets"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    protected virtual string[]? TrueScriptBindingKeys { get; } = null;

    /// <summary>
    /// Returns the name of the widget to invalidate when the <see cref="Enabled"/> property returns false; or null, if no widget should be invalidated.  This 
    /// property is used to bind the <see cref="FalseWidgets"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    protected virtual string[]? FalseScriptBindingKeys { get; } = null;

    /// <summary>
    /// Returns the widget to invalidate when the <see cref="Enabled"/> property returns true.  This property is bound using the <see cref="TrueWidgetNames"/> property 
    /// during the bind phase.
    /// </summary>
    protected IScript[]? TrueScripts { get; private set; }

    /// <summary>
    /// Returns the widget to invalidate when the <see cref="Enabled"/> property returns false.  This property is bound using the <see cref="FalseWidgetNames"/> property 
    /// during the bind phase.
    /// </summary>
    protected IScript[]? FalseScripts { get; private set; }

    public void Bind()
    {
        List<(IBoolValue, bool, int)> conditionalList = new();
        foreach ((string enabledName, bool isTrue, int productOfSumsTerm) in EnabledNames)
        {
            IBoolValue boolValue = Game.SingletonRepository.Get<IBoolValue>(enabledName);
            conditionalList.Add((boolValue, isTrue, productOfSumsTerm));
        }
        Enabled = conditionalList.ToArray();
        TrueScripts = Game.SingletonRepository.GetNullable<IScript>(TrueScriptBindingKeys);
        FalseScripts = Game.SingletonRepository.GetNullable<IScript>(FalseScriptBindingKeys);
    }

    public string ToJson()
    {
        ConditionalScriptGameConfiguration gameConfiguration = new()
        {
            Key = Key,
            EnabledNames = EnabledNames,
            TrueScriptBindingKeys = TrueScriptBindingKeys,
            FalseScriptBindingKeys = FalseScriptBindingKeys
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }

    public void ExecuteScript()
    {
        if (EvaluateEnabledExpression)
        {
            if (TrueScripts is not null)
            {
                foreach (IScript script in TrueScripts)
                {
                    script.ExecuteScript();
                }
            }
        }
        else
        {
            if (FalseScripts is not null)
            {
                foreach (IScript script in FalseScripts)
                {
                    script.ExecuteScript();
                }
            }
        }
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
            foreach ((IBoolValue condition, bool isTrue, int productOfSumsTerm) in Enabled)
            {
                if (!terms.ContainsKey(productOfSumsTerm))
                {
                    bool conditionIsTrue = condition.BoolValue;
                    terms.Add(productOfSumsTerm, conditionIsTrue);
                }
                else if (terms[productOfSumsTerm] == false) // Short circuit evaluation
                {
                    bool conditionIsTrue = condition.BoolValue;
                    terms[productOfSumsTerm] |= conditionIsTrue;
                }
            }
            if (terms.Any(termAndResult => !termAndResult.Value))
            {
                return false;
            }
            return true;
        }
    }

    public virtual string Key { get; }
    public string GetKey => Key;

}
