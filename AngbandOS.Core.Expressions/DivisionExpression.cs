namespace AngbandOS.Core.Expressions
{
    public class DivisionExpression : Expression
    {
        public readonly Expression Dividend;
        public readonly Expression Divisor;
        public DivisionExpression(Expression dividend, Expression divisor)
        {
            Dividend = dividend;
            Divisor = divisor;
        }
    }
}
