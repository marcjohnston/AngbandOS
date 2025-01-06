namespace AngbandOS.Core.Expressions
{
    public class MultiplicationExpression : Expression
    {
        public readonly Expression Factor1;
        public readonly Expression Factor2;
        public MultiplicationExpression(Expression factor1, Expression factor2)
        {
            Factor1 = factor1;
            Factor2 = factor2;
        }
    }
}
