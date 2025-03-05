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
    public override Type[] ResultTypes => new Type[] { typeof(IntegerExpression) };
    public override Expression Compute()
    {
        IntegerExpression diceIntegerExpression = Game.ComputeIntegerExpression(Dice);
        IntegerExpression sidesIntegerExpression = Game.ComputeIntegerExpression(Sides);
        Random random = Game.UseRandom;
        int sum = 0;
        for (int rollIndex = 0; rollIndex < diceIntegerExpression.Value; rollIndex++)
        {
            int roll = random.Next(sidesIntegerExpression.Value);
            sum += roll;
        }
        return new IntegerExpression(sum);
    }
    public override string ToString()
    {
        return $"{Dice}d{Sides}";
    }
}
