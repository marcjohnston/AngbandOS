
namespace AngbandOS.Core.Expressions;

[Serializable]
public class IntegerToDecimalExpressionTypeConverter : ExpressionTypeConverter
{
    public override Type FromExpressionType => typeof(IntegerExpression);
    public override Type ToExpressionType => typeof(DecimalExpression);
    public override Expression Convert(Expression expression)
    {
        IntegerExpression integerExpression = (IntegerExpression)expression;
        return new DecimalExpression(integerExpression.Value);
    }
}