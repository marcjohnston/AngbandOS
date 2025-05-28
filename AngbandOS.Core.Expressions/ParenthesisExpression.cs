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
        Expression expression = Expression.Compute();
        if (Sign.HasValue)
        {
            switch (expression)
            {
                case IntegerExpression integerExpression:
                    return new IntegerExpression(Sign.Value ? integerExpression.Value : -integerExpression.Value);
                case DecimalExpression decimalExpression:
                    return new DecimalExpression(Sign.Value ? decimalExpression.Value : -decimalExpression.Value);
                default:
                    throw new Exception("Invalid type for signed parenthesis");
            }
        }
        return expression;
    }
    public override string ToString()
    {
        string signSymbol = "";
        if (Sign.HasValue)
        {
            signSymbol = Sign.Value ? "+" : "-";
        }
        return $"{signSymbol}({Expression})";
    }
}
