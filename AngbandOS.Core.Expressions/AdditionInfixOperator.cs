namespace AngbandOS.Core.Expressions
{
    public class AdditionInfixOperator : InfixOperator
    {
        public override string OperatorSymbol => "+";
        public override InfixExpression CreateExpression(Expression operand1, Expression operand2) => new AdditionExpression(operand1, operand2);
    }
}
