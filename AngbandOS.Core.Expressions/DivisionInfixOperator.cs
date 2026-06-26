namespace AngbandOS.Core.Expressions;

public class DivisionInfixOperator : InfixOperator
{
    public override string OperatorSymbol => "/";
    public override InfixExpression CreateExpression(Expression operand1, Expression operand2) => new DivisionInfixExpression(operand1, operand2);
}
