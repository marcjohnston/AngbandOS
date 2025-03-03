namespace AngbandOS.Core.Expressions;

[Serializable]
public class DivisionInfixOperator : InfixOperator
{
    public override string OperatorSymbol => "/";
    public override InfixExpression CreateExpression(Expression operand1, Expression operand2) => new DivisionExpression(operand1, operand2);
}
