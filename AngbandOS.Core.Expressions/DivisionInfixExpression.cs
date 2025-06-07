namespace AngbandOS.Core.Expressions;

[Serializable]
public class DivisionInfixExpression : InfixExpression
{
    public DivisionInfixExpression(Expression dividend, Expression divisor) : base(dividend, divisor) { }
    public Expression Dividend => Operand1;
    public Expression Divisor => Operand2;
    public override Type[] ResultTypes => new Type[] { typeof(IntegerExpression), typeof(DecimalExpression) };
    public override Expression Compute()
    {
        Expression computedDividend = Dividend.Compute();
        Expression computedDivisor = Divisor.Compute();
        Expression? computedExpression = TryDivide(computedDividend, computedDivisor);

        if (computedExpression is null)
        {
            throw new Exception($"Incompatible types for division {computedDividend.Text} and {computedDivisor.Text}");
        }
        return computedExpression;
    }
    public override string Text => $"{Dividend}/{Divisor}";
    private Expression? TryDivide(Expression dividend, Expression divisor)
    {
        if (divisor is DecimalExpression divisorDecimalExpression)
        {
            if (divisorDecimalExpression.Value == 0)
            {
                throw new Exception("Divide by zero error.");
            }
            else if (dividend is DecimalExpression dividendDecimalExpression)
            {
                return new DecimalExpression(dividendDecimalExpression.Value / divisorDecimalExpression.Value);
            }
            else if (dividend is IntegerExpression dividendIntegerExpression)
            {
                return new DecimalExpression((double)dividendIntegerExpression.Value / divisorDecimalExpression.Value);
            }
        }
        else if (divisor is IntegerExpression divisorIntegerExpression)
        {
            if (divisorIntegerExpression.Value == 0)
            {
                throw new Exception("Divide by zero error.");
            }
            else if (dividend is DecimalExpression dividendDecimalExpression)
            {
                return new DecimalExpression(dividendDecimalExpression.Value / (double)divisorIntegerExpression.Value);
            }
            else if (dividend is IntegerExpression dividendIntegerExpression)
            {
                // Test if the division produces an integer.
                (int quotient, int remainder) = Math.DivRem(dividendIntegerExpression.Value, divisorIntegerExpression.Value);
                if (remainder == 0)
                {
                    return new IntegerExpression(quotient);
                }
                else
                {
                    return new DecimalExpression((double)dividendIntegerExpression.Value / (double)divisorIntegerExpression.Value);
                }
            }
        }
        return null;
    }

    public override Expression Minimize(MinimizeOptions options)
    {
        Expression minimizedDividend = Dividend.Minimize(options);
        Expression minimizedDivisor = Divisor.Minimize(options);

        // Check for identities. x/1=x
        if (minimizedDivisor is IntegerExpression minimizedIntegerDivisorExpression && minimizedIntegerDivisorExpression.Value == 1)
        {
            return minimizedDividend;
        }
        else if (minimizedDivisor is DecimalExpression minimizedDecimalDivisorExpression && minimizedDecimalDivisorExpression.Value == 1)
        {
            return minimizedDividend;
        }
        Expression? minimizedExpression = TryDivide(minimizedDividend, minimizedDivisor);
        if (options.DivideOnlyOnfIntegerResult && minimizedExpression is DecimalExpression && minimizedDividend is IntegerExpression && minimizedDivisor is IntegerExpression)
        {
            return new DivisionInfixExpression(minimizedDividend, minimizedDivisor);
        }
        return minimizedExpression ?? new DivisionInfixExpression(minimizedDividend, minimizedDivisor);
    }
}
