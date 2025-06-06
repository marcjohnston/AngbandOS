namespace AngbandOS.Core.Expressions;

[Serializable]
public class MultiplicationInfixOperator : InfixOperator
{
    public override string OperatorSymbol => "*";
    public override InfixExpression CreateExpression(Expression operand1, Expression operand2) => new MultiplicationInfixExpression(operand1, operand2);
}
