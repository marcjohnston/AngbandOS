namespace AngbandOS.Core.Expressions;

[Serializable]
public abstract class Expression
{
    /// <summary>
    /// Computes and returns the result.
    /// </summary>
    /// <returns></returns>
    public abstract Expression Compute();

    /// <summary>
    /// Computes and returns the result.  A test to ensure the result is of a specific type <typeparamref name="TExpression"/> is also performed.
    /// </summary>
    /// <typeparam name="TExpression"></typeparam>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public TExpression Compute<TExpression>()
    {
        Expression result = Compute();
        if (result is TExpression castResult)
        {
            return castResult;
        }
        throw new Exception($"Invalid result from Expression.Compute.  A result of type {typeof(TExpression).Name} was expected.");
    }
}
