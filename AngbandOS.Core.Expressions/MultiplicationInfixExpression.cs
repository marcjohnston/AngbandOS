using System.Numerics;
namespace AngbandOS.Core.Expressions;

[Serializable]
public class MultiplicationInfixExpression : InfixExpression
{
    public MultiplicationInfixExpression(Expression factor1, Expression factor2) : base(factor1, factor2) { }
    public Expression Factor1 => Operand1;
    public Expression Factor2 => Operand2;

    public override Type[] ResultTypes => new Type[] { typeof(IntegerExpression), typeof(DecimalExpression) };
    public override Expression Compute()
    {
        Expression computedFactor1 = Factor1.Compute();
        Expression computedFactor2 = Factor2.Compute();
        Expression? computedExpression = TryMultiply(computedFactor1, computedFactor2);

        if (computedExpression is null)
        {
            throw new Exception($"Incompatible types for multiplication {computedFactor1.Text} and {computedFactor2.Text}");
        }
        return computedExpression;
    }
    private Expression? TryMultiply(Expression factor1, Expression factor2)
    {
        if (factor1 is DecimalExpression factor1DecimalExpression)
        {
            if (factor2 is DecimalExpression addend2DecimalExpression)
            {
                return new DecimalExpression(factor1DecimalExpression.Value * addend2DecimalExpression.Value);
            }
            else if (factor2 is IntegerExpression factor2IntegerExpression)
            {
                return new DecimalExpression(factor1DecimalExpression.Value * factor2IntegerExpression.Value);
            }
        }
        else if (factor1 is IntegerExpression factor1IntegerExpression)
        {
            if (factor2 is DecimalExpression factor2DecimalExpression)
            {
                return new DecimalExpression(factor1IntegerExpression.Value * factor2DecimalExpression.Value);
            }
            else if (factor2 is IntegerExpression factor2IntegerExpression)
            {
                return new IntegerExpression(factor1IntegerExpression.Value * factor2IntegerExpression.Value);
            }
        }
        return null;
    }

    public override string Text => $"{Factor1}*{Factor2}";
    public override Expression Minimize(MinimizeOptions options)
    {
        Expression minimizedFactor1 = Factor1.Minimize(options);
        Expression minimizedFactor2 = Factor2.Minimize(options);

        // Check for identities. x*1=x, 1*x=x, x*0=0, 0*x=x
        if (minimizedFactor1 is IntegerExpression minimizedIntegerFactor1Expression)
        {
            if (minimizedIntegerFactor1Expression.Value == 1)
            {
                return minimizedFactor2;
            }
            else if (minimizedIntegerFactor1Expression.Value == 0)
            {
                return new IntegerExpression(0);
            }
        }
        else if (minimizedFactor1 is DecimalExpression minimizedDecimalFactor1Expression)
        {
            if (minimizedDecimalFactor1Expression.Value == 1)
            {
                return minimizedFactor2;
            }
            else if (minimizedDecimalFactor1Expression.Value == 0)
            {
                return new IntegerExpression(0);
            }
        }
        else if (minimizedFactor2 is IntegerExpression minimizedIntegerFactor2Expression)
        {
            if (minimizedIntegerFactor2Expression.Value == 1)
            {
                return minimizedFactor1;
            }
            else if (minimizedIntegerFactor2Expression.Value == 0)
            {
                return new IntegerExpression(0);
            }
        }
        else if (minimizedFactor1 is DecimalExpression minimizedDecimalFactor2Expression)
        {
            if (minimizedDecimalFactor2Expression.Value == 1)
            {
                return minimizedFactor1;
            }
            else if (minimizedDecimalFactor2Expression.Value == 0)
            {
                return new IntegerExpression(0);
            }
        }
        Expression? minimizedExpression = minimizedExpression = TryMultiply(minimizedFactor1, minimizedFactor2);
        return minimizedExpression ?? new MultiplicationInfixExpression(minimizedFactor1, minimizedFactor2);
    }
}
