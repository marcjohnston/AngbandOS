namespace AngbandOS.Core.Expressions;

[Serializable]
public abstract class InfixOperator
{
    public abstract string OperatorSymbol { get; }
    public abstract InfixExpression CreateExpression(Expression operand1, Expression operand2);
}
