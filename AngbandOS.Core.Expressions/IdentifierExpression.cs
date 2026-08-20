namespace AngbandOS.Core.Expressions;

public abstract class IdentifierExpression : Expression
{
    public readonly string Identifier;
    public readonly bool? Sign;

    public IdentifierExpression(string identifier, bool? sign = null)
    {
        Identifier = identifier;
        Sign = sign;
    }

    /// <summary>
    /// Derived expressions compute their unsigned value here.  The sign is applied by Compute.
    /// </summary>
    protected abstract Expression ComputeIdentifier(Dictionary<string, object> providers);

    public override Expression Compute(Dictionary<string, object> providers)
    {
        Expression computedExpression = ComputeIdentifier(providers);

        if (!Sign.HasValue || Sign.Value)
        {
            return computedExpression;
        }

        switch (computedExpression)
        {
            case IntegerExpression integerExpression:
                return new IntegerExpression(-integerExpression.Value);
            case DecimalExpression decimalExpression:
                return new DecimalExpression(-decimalExpression.Value);
            default:
                throw new Exception($"Invalid type for signed identifier {Identifier}.");
        }
    }

    public override string Text
    {
        get
        {
            string signSymbol = "";
            if (Sign.HasValue)
            {
                signSymbol = Sign.Value ? "+" : "-";
            }
            return $"{signSymbol}{Identifier}";
        }
    }
}
