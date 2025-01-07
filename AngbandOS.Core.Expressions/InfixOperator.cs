namespace AngbandOS.Core.Expressions
{
    public abstract class InfixOperator
    {
        public abstract string OperatorSymbol { get; }
        public abstract InfixExpression CreateExpression(Expression operand1, Expression operand2);
    }
}
