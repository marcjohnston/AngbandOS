namespace AngbandOS.Core.Expressions;

/// <summary>
/// Represents an infix operator for bonus level in the form of (max_value)b(max_depth). This operator is used to calculate the bonus level based on the maximum value and maximum depth provided as operands. The result of this operation is a new DiceRollInfixExpression that encapsulates the logic for calculating the bonus level.
/// </summary>
internal class BonusInfixOperator : InfixOperator
{
    public override string OperatorSymbol => "b";
    public override InfixExpression CreateExpression(Expression operand1, Expression operand2) => new BonusInfixExpression(operand1, operand2);
}
