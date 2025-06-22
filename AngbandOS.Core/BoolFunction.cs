
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Functions;

[Serializable]
internal abstract class BoolFunction : IChangeTracker, IGetKey, IBoolValue
{
    protected readonly Game Game;
    protected BoolFunction(Game game) 
    {
        Game = game;
    }

    /// <summary>
    /// Returns the boolean result of the function.  This method provides the implementation for the IConditional interface.
    /// </summary>
    public abstract bool BoolValue { get; }

    /// <summary>
    /// Returns true, if there are no dependencies or if any the change tracking on any dependency is flagged as changed.
    /// </summary>
    public bool IsChanged => Dependencies == null ? true : Dependencies.Any(_dependency => _dependency.IsChanged);

    /// <summary>
    /// Does nothing, because functions are not sinks for tracking.
    /// </summary>
    public void ClearChangedFlag() { }

    protected IChangeTracker[]? Dependencies { get; private set; }
    public string ToJson()
    {
        return "";
    }
    public string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind()
    {
        Dependencies = Game.SingletonRepository.GetNullable<IChangeTracker>(DependencyNames);
    }

    public virtual string[]? DependencyNames => null;
}

[Serializable]
internal abstract class BoolPosFunction : IChangeTracker, IGetKey, IBoolValue
{
    protected readonly Game Game;
    protected BoolPosFunction(Game game) 
    {
        Game = game;
    }

    /// <summary>
    /// Returns true, if there are no dependencies or if any the change tracking on any dependency is flagged as changed.
    /// </summary>
    public bool IsChanged => Dependencies == null ? true : Dependencies.Any(_dependency => _dependency.IsChanged);

    /// <summary>
    /// Does nothing, because functions are not sinks for tracking.
    /// </summary>
    public void ClearChangedFlag() { }

    protected IChangeTracker[]? Dependencies { get; private set; }
    public string ToJson()
    {
        return "";
    }
    public string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind()
    {
        Dependencies = Game.SingletonRepository.GetNullable<IChangeTracker>(DependencyNames);
        List<(IBoolValue, bool, int)> conditionalList = new();
        foreach ((string enabledName, bool isTrue, int productOfSumsTerm) in EnabledNames)
        {
            IBoolValue boolValue = Game.SingletonRepository.Get<IBoolValue>(enabledName);
            conditionalList.Add((boolValue, isTrue, productOfSumsTerm));
        }
        Enabled = conditionalList.ToArray();
    }

    public virtual string[]? DependencyNames => null;

    /// <summary>
    /// Returns an array of the names of the conditionals that need to be met for the widget to rendered; or null, if there are no conditions.  All conditions must return true for 
    /// the widget to be enabled.  This property is bound used to bind the Enabled property during the binding phase.  The conditions are a boolean expression in the form of a product of sums (POS)
    /// that determine if the widget is enabled when the result matches the <see cref="valueConditionalMustBe"/> parameter.  The <see cref="term"/> parameter is used to determine
    /// the conditions that make up a term.  All conditions with the same term value are considered to belong to the same term (sum).  Use Gaussian Elimination to convert existing
    /// boolean expressions into POS format.
    /// </summary>
    protected virtual (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames { get; }

    /// <summary>
    /// Returns an array of conditionals that need to be met for the widget to rendered; or null, if there are no conditions.  All conditions must return true for the widget
    /// to be enabled.  This property is bound from the EnabledNames property during the binding phase.  The conditions are a boolean expression in the form of a product of sums (POS)
    /// that determine if the widget is enabled when the result matches the <see cref="valueConditionalMustBe"/> parameter.  The <see cref="productOfSumsTerm"/> parameter is used to determine
    /// the conditions that make up a term using a Product-Of-Sums formula.  All conditions with the same term value are considered to belong to the same term (sum).  Use Gaussian Elimination to convert existing
    /// boolean expressions into POS format.
    /// </summary>
    protected (IBoolValue conditional, bool valueConditionalMustBe, int productOfSumsTerm)[] Enabled { get; private set; }

    /// <summary>
    /// Evaluates the <see cref="Enabled"/> property as a Product of Sums expression and returns true or false accordingly.
    /// </summary>
    public bool BoolValue
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
}