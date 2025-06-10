using System.Numerics;
namespace AngbandOS.Core.Expressions;

[Serializable]
public class SubtractionInfixExpression : InfixExpression
{
    public SubtractionInfixExpression(Expression minuend, Expression subtrahend) : base(minuend, subtrahend) { }
    public Expression Minuend => Operand1;
    public Expression Subtrahend => Operand2;
    public override Type[] ResultTypes => new Type[] { typeof(IntegerExpression), typeof(DecimalExpression) };
    public override Expression Compute()
    {
        Expression computedMinuend = Minuend.Compute();
        Expression computedSubtrahend = Subtrahend.Compute();
        Expression? computedExpression = TrySubtract(computedMinuend, computedSubtrahend);

        if (computedExpression is null)
        {
            throw new Exception($"Incompatible types for subtraction {computedMinuend.Text} and {computedSubtrahend.Text}");
        }
        return computedExpression;
    }
    private Expression? TrySubtract(Expression minuend, Expression subtrahend)
    {
        if (minuend is DecimalExpression minuendDecimalExpression)
        {
            if (subtrahend is DecimalExpression subtrahendDecimalExpression)
            {
                return new DecimalExpression(minuendDecimalExpression.Value - subtrahendDecimalExpression.Value);
            }
            else if (subtrahend is IntegerExpression subtrahendIntegerExpression)
            {
                return new DecimalExpression(minuendDecimalExpression.Value - subtrahendIntegerExpression.Value);
            }
        }
        else if (minuend is IntegerExpression minuendIntegerExpression)
        {
            if (subtrahend is DecimalExpression subtrahendDecimalExpression)
            {
                return new DecimalExpression(minuendIntegerExpression.Value - subtrahendDecimalExpression.Value);
            }
            else if (subtrahend is IntegerExpression subtrahendIntegerExpression)
            {
                return new IntegerExpression(minuendIntegerExpression.Value - subtrahendIntegerExpression.Value);
            }
        }
        return null;
    }
    public override string Text => $"{Minuend}-{Subtrahend}";
    public override Expression Minimize(MinimizeOptions options)
    {
        Expression minimizedMinuend = Minuend.Minimize(options);
        Expression minimizedSubtrahend = Subtrahend.Minimize(options);

        // Check for identities. x-0=x, 0-x=-x
        if (minimizedSubtrahend is IntegerExpression minimizedIntegerSubtrahendExpression && minimizedIntegerSubtrahendExpression.Value == 0)
        {
            return minimizedMinuend;
        }
        else if (minimizedSubtrahend is DecimalExpression minimizedDecimalSubtrahendExpression && minimizedDecimalSubtrahendExpression.Value == 0)
        {
            return minimizedMinuend;
        }
        else if (minimizedMinuend is IntegerExpression minimizedIntegerMinuendExpression && minimizedIntegerMinuendExpression.Value == 0)
        {
            Expression parenthesisExpression = new ParenthesisExpression(minimizedSubtrahend, false);
            return parenthesisExpression.Minimize(options);
        }
        else if (minimizedMinuend is DecimalExpression minimizedDecimalMinuendExpression && minimizedDecimalMinuendExpression.Value == 0)
        {
            Expression parenthesisExpression = new ParenthesisExpression(minimizedSubtrahend, false);
            return parenthesisExpression.Minimize(options);
        }
        Expression? minimizedExpression = minimizedExpression = TrySubtract(minimizedSubtrahend, minimizedSubtrahend);
        return minimizedExpression ?? new SubtractionInfixExpression(minimizedMinuend, minimizedSubtrahend);
    }
}
