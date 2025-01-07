namespace AngbandOS.Core.Expressions.IDE;

public class DiceRollExpression : InfixExpression
{
    public DiceRollExpression(Expression dice, Expression sides) : base(dice, sides) { }
    public Expression Dice => base.Operand1;
    public Expression Sides => base.Operand2;
    public override Expression Compute()
    {
        Expression dice = Dice.Compute();
        Expression sides = Sides.Compute();
        if (Dice is IntegerExpression diceIntegerExpression && Sides is IntegerExpression sidesIntegerExpression)
        {
            Random random = new Random();
            int sum = 0;
            for (int rollIndex = 0; rollIndex < diceIntegerExpression.Value; rollIndex++)
            {
                int roll = random.Next(sidesIntegerExpression.Value);
                sum += roll;
            }
            return new IntegerExpression(sum);
        }
        throw new Exception("Invalid data types for addition.");
    }
}
