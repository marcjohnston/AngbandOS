namespace AngbandOS.Core.Expressions;

[Serializable]
public class AdditionInfixOperator : InfixOperator
{
    public override string OperatorSymbol => "+";
    public override InfixExpression CreateExpression(Expression operand1, Expression operand2) => new AdditionInfixExpression(operand1, operand2);
}
