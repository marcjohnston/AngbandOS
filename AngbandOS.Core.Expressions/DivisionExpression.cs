namespace AngbandOS.Core.Expressions;

[Serializable]
public class DivisionExpression : InfixExpression
{
    public DivisionExpression(Expression dividend, Expression divisor) : base(dividend, divisor) { }
    public Expression Dividend => Operand1;
    public Expression Divisor => Operand2;
    public override Type[] ResultTypes => new Type[] { typeof(IntegerExpression), typeof(DecimalExpression) };
    public override Expression Compute()
    {
        Expression dividend = Dividend.Compute();
        Expression divisor = Divisor.Compute();

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
            throw new Exception($"Dividend does not support {dividend.GetType().Name}");
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
            throw new Exception($"Dividend does not support {dividend.GetType().Name}");
        }

        throw new Exception($"Divisor does not support {divisor.GetType().Name}");
    }
    public override string ToString()
    {
        return $"{Dividend}/{Divisor}";
    }
}
