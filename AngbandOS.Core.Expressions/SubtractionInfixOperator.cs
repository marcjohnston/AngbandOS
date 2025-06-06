namespace AngbandOS.Core.Expressions;

[Serializable]
public class SubtractionInfixOperator : InfixOperator
{
    public override string OperatorSymbol => "-";
    public override InfixExpression CreateExpression(Expression operand1, Expression operand2) => new SubtractionInfixExpression(operand1, operand2);
}
