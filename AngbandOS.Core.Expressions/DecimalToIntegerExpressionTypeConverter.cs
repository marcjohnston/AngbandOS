
namespace AngbandOS.Core.Expressions;

[Serializable]
public class DecimalToIntegerExpressionTypeConverter : ExpressionTypeConverter
{
    public override Type FromExpressionType => typeof(DecimalExpression);
    public override Type ToExpressionType => typeof(IntegerExpression);
    public override Expression Convert(Expression expression)
    {
        DecimalExpression decimalExpression = (DecimalExpression)expression;
        return new IntegerExpression((int)decimalExpression.Value);
    }
}