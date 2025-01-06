namespace AngbandOS.Core.Expressions
{
    public class SubtractionExpression : Expression
    {
        public readonly Expression Minuend;
        public readonly Expression Subtrahend;
        public SubtractionExpression(Expression minuend, Expression subtrahend)
        {
            Minuend = minuend;
            Subtrahend = subtrahend;
        }
    }
}
