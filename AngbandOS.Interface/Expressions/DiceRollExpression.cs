
using AngbandOS.Core.Expressions;

namespace AngbandOS.Core.Interface;

public class DiceRollExpression : InfixExpression
{
    public DiceRollExpression(Expression dice, Expression sides) : base(dice, sides) { }
    public Expression Dice => base.Operand1;
    public Expression Sides => base.Operand2;
}
