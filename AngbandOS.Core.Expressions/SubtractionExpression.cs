namespace AngbandOS.Core.Expressions
{
    public class SubtractionExpression : InfixExpression
    {
        public SubtractionExpression(Expression minuend, Expression subtrahend) : base(minuend, subtrahend) { }
        public Expression Minuend => base.Operand1;
        public Expression Subtrahend => base.Operand1;
    }
}
