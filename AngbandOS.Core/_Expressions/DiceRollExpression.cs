namespace AngbandOS.Core.Expressions;

[Serializable]
internal class DiceRollExpression : InfixExpression
{
    public readonly Game Game;
    public DiceRollExpression(Game game, Expression dice, Expression sides) : base(dice, sides)
    {
        Game = game;
    }
    public Expression Dice => base.Operand1;
    public Expression Sides => base.Operand2;
    public override Expression Compute()
    {
        Expression dice = Dice.Compute();
        Expression sides = Sides.Compute();
        if (Dice is IntegerExpression diceIntegerExpression && Sides is IntegerExpression sidesIntegerExpression)
        {
            Random random = Game.UseRandom;
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
    public override string ToString()
    {
        return $"{Dice}d{Sides}";
    }
}
