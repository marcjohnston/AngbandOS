namespace AngbandOS.Core.Expressions;

[Serializable]
public class MultiplicationExpression : InfixExpression
{
    public MultiplicationExpression(Expression factor1, Expression factor2) : base(factor1, factor2) { }
    public Expression Factor1 => Operand1;
    public Expression Factor2 => Operand2;

    public override Type[] ResultTypes => new Type[] { typeof(IntegerExpression), typeof(DecimalExpression) };
    public override Expression Compute()
    {
        Expression factor1 = Factor1.Compute();
        Expression factor2 = Factor2.Compute();
        if (factor1 is DecimalExpression factor1DecimalExpression)
        {
            if (factor2 is DecimalExpression addend2DecimalExpression)
            {
                return new DecimalExpression(factor1DecimalExpression.Value + addend2DecimalExpression.Value);
            }
            else if (factor2 is IntegerExpression factor2IntegerExpression)
            {
                return new DecimalExpression(factor1DecimalExpression.Value + factor2IntegerExpression.Value);
            }

            throw new Exception($"Factor2 does not support {factor2.GetType().Name}");
        }
        else if (factor1 is IntegerExpression factor1IntegerExpression)
        {
            if (factor2 is DecimalExpression factor2DecimalExpression)
            {
                return new DecimalExpression(factor1IntegerExpression.Value + factor2DecimalExpression.Value);
            }
            else if (factor2 is IntegerExpression factor2IntegerExpression)
            {
                return new IntegerExpression(factor1IntegerExpression.Value + factor2IntegerExpression.Value);
            }

            throw new Exception($"Factor2 does not support {factor2.GetType().Name}");
        }

        throw new Exception($"Factor1 does not support {factor1.GetType().Name}");
    }
    public override string ToString()
    {
        return $"{Factor1}*{Factor2}";
    }
}
