using System.Numerics;

namespace AngbandOS.Core.Expressions;

[Serializable]
public class SubtractionExpression : InfixExpression
{
    public SubtractionExpression(Expression minuend, Expression subtrahend) : base(minuend, subtrahend) { }
    public Expression Minuend => Operand1;
    public Expression Subtrahend => Operand2;
    public override Type[] ResultTypes => new Type[] { typeof(IntegerExpression), typeof(DecimalExpression) };
    public override Expression Compute()
    {
        Expression minuend = Minuend.Compute();
        Expression subtrahend = Subtrahend.Compute();
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

            throw new Exception($"Subtrahend does not support {subtrahend.GetType().Name}");
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

            throw new Exception($"Subtrahend does not support {subtrahend.GetType().Name}");
        }

        throw new Exception($"Minuend does not support {minuend.GetType().Name}");
    }
    public override string ToString()
    {
        return $"{Minuend}-{Subtrahend}";
    }
}
