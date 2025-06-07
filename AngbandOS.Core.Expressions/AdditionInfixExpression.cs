using System.Linq.Expressions;

namespace AngbandOS.Core.Expressions;

[Serializable]
public class AdditionInfixExpression : InfixExpression
{
    public AdditionInfixExpression(Expression addend1, Expression addend2) : base(addend1, addend2) { }
    public Expression Addend1 => Operand1;
    public Expression Addend2 => Operand2;
    public override Type[] ResultTypes => new Type[] { typeof(IntegerExpression), typeof(DecimalExpression) };
    public override Expression Compute()
    {
        Expression computedAddend1 = Addend1.Compute();
        Expression computedAddend2 = Addend2.Compute();
        Expression? computedExpression = TryAdd(computedAddend1, computedAddend2);

        if (computedExpression is null)
        {
            throw new Exception($"Incompatible types for addition {computedAddend1.Text} and {computedAddend2.Text}");
        }
        return computedExpression;
    }
    public override string Text => $"{Addend1}+{Addend2}";
    private Expression? TryAdd(Expression addend1, Expression addend2)
    {
        if (addend1 is DecimalExpression addend1DecimalExpression)
        {
            if (addend2 is DecimalExpression addend2DecimalExpression)
            {
                return new DecimalExpression(addend1DecimalExpression.Value + addend2DecimalExpression.Value);
            }
            else if (addend2 is IntegerExpression addend2IntegerExpression)
            {
                return new DecimalExpression(addend1DecimalExpression.Value + addend2IntegerExpression.Value);
            }
        }
        else if (addend1 is IntegerExpression addend1IntegerExpression)
        {
            if (addend2 is DecimalExpression addend2DecimalExpression)
            {
                return new DecimalExpression(addend1IntegerExpression.Value + addend2DecimalExpression.Value);
            }
            else if (addend2 is IntegerExpression addend2IntegerExpression)
            {
                return new IntegerExpression(addend1IntegerExpression.Value + addend2IntegerExpression.Value);
            }
        }
        return null;
    }
    public override Expression Minimize(MinimizeOptions options)
    {
        Expression minimizedAddend1 = Addend1.Minimize(options);
        Expression minimizedAddend2 = Addend2.Minimize(options);

        // Check for identities. x+0=x, 0+x=x
        if (minimizedAddend1 is IntegerExpression minimizedIntegerAddend1Expression && minimizedIntegerAddend1Expression.Value == 0)
        {
            return minimizedAddend2;
        }
        else if (minimizedAddend1 is DecimalExpression minimizedDecimalAddend1Expression && minimizedDecimalAddend1Expression.Value == 0)
        {
            return minimizedAddend2;
        }
        else if (minimizedAddend2 is IntegerExpression minimizedIntegerAddend2Expression && minimizedIntegerAddend2Expression.Value == 0)
        {
            return minimizedAddend1;
        }
        else if (minimizedAddend2 is DecimalExpression minimizedDecimalAddend2Expression && minimizedDecimalAddend2Expression.Value == 0)
        {
            return minimizedAddend1;
        }

        Expression? minimizedExpression = TryAdd(minimizedAddend1, minimizedAddend2);
        return minimizedExpression ?? new AdditionInfixExpression(minimizedAddend1, minimizedAddend2);
    }
}
