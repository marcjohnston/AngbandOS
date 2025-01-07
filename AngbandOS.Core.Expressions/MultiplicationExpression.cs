namespace AngbandOS.Core.Expressions
{
    public class MultiplicationExpression : InfixExpression
    {
        public MultiplicationExpression(Expression factor1, Expression factor2) : base(factor1, factor2) { }
        public Expression Factor1 => base.Operand1;
        public Expression Factor2 => base.Operand2;
    }
}
