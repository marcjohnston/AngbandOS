namespace AngbandOS.Core.Expressions;

public class DiceRollExpression : InfixExpression
{
    public DiceRollExpression(Expression dice, Expression sides) : base(dice, sides) { }
    public Expression Dice => base.Operand1;
    public Expression Sides => base.Operand2;
}
