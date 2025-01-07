namespace AngbandOS.Core.Expressions
{
    public class DivisionExpression : InfixExpression
    {
        public DivisionExpression(Expression dividend, Expression divsor) : base(dividend, divsor) { }
        public Expression Dividend => base.Operand1;
        public Expression Divisor => base.Operand2;
    }
}
