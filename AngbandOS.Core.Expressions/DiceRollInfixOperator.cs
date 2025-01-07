namespace AngbandOS.Core.Expressions
{
    public class DiceRollInfixOperator : InfixOperator
    {
        public override string OperatorSymbol => "d";
        public override InfixExpression CreateExpression(Expression operand1, Expression operand2) => new DiceRollExpression(operand1, operand2);
    }
}
