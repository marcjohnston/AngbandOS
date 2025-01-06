
namespace AngbandOS.Core.Expressions
{
    public class DiceRollExpression : Expression
    {
        public readonly Expression Dice;
        public readonly Expression Sides;
        public DiceRollExpression(Expression dice, Expression sides)
        {
            Dice = dice;
            Sides = sides;
        }
    }
}
