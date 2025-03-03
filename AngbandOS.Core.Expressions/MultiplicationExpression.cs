namespace AngbandOS.Core.Expressions;

[Serializable]
public class MultiplicationExpression : InfixExpression
{
    public MultiplicationExpression(Expression factor1, Expression factor2) : base(factor1, factor2) { }
    public Expression Factor1 => base.Operand1;
    public Expression Factor2 => base.Operand2;

    public override Expression Compute()
    {
        Expression factor1 = Factor1.Compute();
        Expression factor2 = Factor2.Compute();
        if (factor1 is IntegerExpression factor1IntegerExpression && factor2 is IntegerExpression factor2IntegerExpression)
        {
            return new IntegerExpression(factor1IntegerExpression.Value * factor2IntegerExpression.Value);
        }
        throw new Exception("Invalid data types for multiplication.");
    }
    public override string ToString()
    {
        return $"{Factor1}*{Factor2}";
    }
}
