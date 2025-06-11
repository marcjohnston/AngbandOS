namespace AngbandOS.Core.Expressions;

[Serializable]
public class ParenthesisExpression : Expression
{
    public readonly Expression Expression;
    public readonly bool? Sign;
    public ParenthesisExpression(Expression expression, bool? sign = null)
    {
        Expression = expression;
        Sign = sign;
    }

    public override Type[] ResultTypes => Expression.ResultTypes;
    public override Expression Compute()
    {
        Expression computedExpression = Expression.Compute();
        Expression? resultExpression = TryCompute(Sign, computedExpression);

        if (resultExpression is null)
        {
            throw new Exception("Invalid type for signed parenthesis");
        }
        return computedExpression;
    }
    private Expression? TryCompute(bool? sign, Expression expression)
    {
        if (Sign.HasValue)
        {
            switch (expression)
            {
                case IntegerExpression integerExpression:
                    return new IntegerExpression(Sign.Value ? integerExpression.Value : -integerExpression.Value);
                case DecimalExpression decimalExpression:
                    return new DecimalExpression(Sign.Value ? decimalExpression.Value : -decimalExpression.Value);
                default:
                    return null;
            }
        }
        return expression;
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
            return $"{signSymbol}({Expression})";
        }
    }
    public override Expression Minimize(MinimizeOptions? options = null)
    {
        Expression minimizedExpression = Expression.Minimize(options);
        Expression? computedExpression = TryCompute(Sign, minimizedExpression);
        return computedExpression ?? new ParenthesisExpression(minimizedExpression, Sign);
    }
}
