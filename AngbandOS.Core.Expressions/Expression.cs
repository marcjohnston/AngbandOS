namespace AngbandOS.Core.Expressions;

public abstract class Expression
{
    /// <summary>
    /// Represents the method that all derived expression need to implement to compute the result of the expression.
    /// </summary>
    /// <returns></returns>
    public abstract Expression Compute(Dictionary<string, object> dependencies);

    /// <summary>
    /// Represents the types of results that the expression can produce that must be implemented by all derived expressions.
    /// </summary>
    public abstract Type[] ResultTypes { get; }

    /// <summary>
    /// Computes and returns the result.  A test to ensure the result is of a specific type <typeparamref name="TExpression"/> is also performed.
    /// </summary>
    /// <typeparam name="TExpression"></typeparam>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public TExpression Compute<TExpression>(ExpressionTypeConverter[]? typeConverters, Dictionary<string, object> providers) where TExpression : Expression
    {
        Expression expression = Compute(providers);
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

    /// <summary>
    /// Represents the method that all derived expression must implement to return the text representation of the expression.
    /// </summary>
    public abstract string Text { get; }

    /// <summary>
    /// Returns the Text representation of the expression for debugging purposes.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => Text;

    /// <summary>
    /// Represents the method that all derived expression can override to minimize the expression.  The default implementation is to return the Compute(providers).
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public virtual Expression Minimize(Dictionary<string, object> providers, MinimizeOptions? options = null) => Compute(providers); // TODO: Would like the options to not be required to be sent.
}
