namespace AngbandOS.Core.Expressions
{
    public abstract class Expression
    {
        public abstract Expression Compute();
        public TExpression Compute<TExpression>()
        {
            Expression result = Compute();
            if (result is TExpression castResult)
            {
                return castResult;
            }
            throw new Exception("Invalid result from Expression.Compute.");
        }
    }
}
