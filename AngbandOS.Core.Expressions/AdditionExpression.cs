using System.Linq.Expressions;

namespace AngbandOS.Core.Expressions;

[Serializable]
public class AdditionExpression : InfixExpression
{
    public AdditionExpression(Expression addend1, Expression addend2) : base(addend1, addend2) { }
    public Expression Addend1 => Operand1;
    public Expression Addend2 => Operand2;
    public override Expression Compute()
    {
        Expression addend1 = Addend1.Compute();
        Expression addend2 = Addend2.Compute();
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

            throw new Exception($"Addend2 does not support {addend2.GetType().Name}");
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

            throw new Exception($"Addend2 does not support {addend2.GetType().Name}");
        }

        throw new Exception($"Addend1 does not support {addend1.GetType().Name}");
    }
    public override string ToString()
    {
        return $"{Addend1}+{Addend2}";
    }
}
