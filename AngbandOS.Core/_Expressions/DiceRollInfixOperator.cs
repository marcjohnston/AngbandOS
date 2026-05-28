namespace AngbandOS.Core.Expressions;

[Serializable]
internal class DiceRollInfixOperator : InfixOperator
{
    public override string OperatorSymbol => "d";
    public override InfixExpression CreateExpression(Expression operand1, Expression operand2) => new DiceRollInfixExpression(operand1, operand2);
}
