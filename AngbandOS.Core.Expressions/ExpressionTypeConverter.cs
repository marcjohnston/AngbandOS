namespace AngbandOS.Core.Expressions;

[Serializable]
public abstract class ExpressionTypeConverter 
{
    public abstract Type FromExpressionType { get; }
    public abstract Type ToExpressionType { get; }
    public abstract Expression Convert(Expression expression);
}
