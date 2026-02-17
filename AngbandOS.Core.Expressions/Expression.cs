namespace AngbandOS.Core.Expressions;

[Serializable]
public abstract class Expression
{
    /// <summary>
    /// Computes and returns the result.
    /// </summary>
    /// <returns></returns>
    public abstract Expression Compute();

    public abstract Type[] ResultTypes { get; }

    /// <summary>
    /// Computes and returns the result.  A test to ensure the result is of a specific type <typeparamref name="TExpression"/> is also performed.
    /// </summary>
    /// <typeparam name="TExpression"></typeparam>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public TExpression Compute<TExpression>(params ExpressionTypeConverter[] typeConverters) where TExpression : Expression
    {
        Expression expression = Compute();
        if (expression is TExpression castResult)
        {
            return castResult;
        }
        if (typeConverters != null)
        {
            foreach (ExpressionTypeConverter typeConverter in typeConverters)
            {
                if (typeConverter.ToExpressionType == typeof(TExpression))
                {
                    return (TExpression)typeConverter.Convert(expression);
                }
            }
        }
        throw new Exception($"Invalid result from Expression.Compute on {expression.ToString()}.  A result of type {typeof(TExpression).Name} was expected.");
    }
    public abstract string Text { get; }
    public override string ToString() => Text;
    public virtual Expression Minimize(MinimizeOptions? options = null) => this; // TODO: Would like the options to not be required to be sent.
}
