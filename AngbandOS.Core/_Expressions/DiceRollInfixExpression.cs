namespace AngbandOS.Core.Expressions;

[Serializable]
internal class DiceRollInfixExpression : InfixExpression
{
    /// <summary>
    /// Returns the game object.  This is needed for access to the Random to compute the dice roll.
    /// </summary>
    public Game Game { get; }
    public DiceRollInfixExpression(Game game, Expression dice, Expression sides) : base(dice, sides)
    {
        Game = game;
    }

    /// <summary>
    /// The number of dice to roll.  This is the left operand of the infix operator.  For example, in "3d6", the dice is 3.  In "d6", the dice is 1.
    /// </summary>
    public Expression Dice => base.Operand1;

    /// <summary>
    /// The number of sides on each die.  This is the right operand of the infix operator.  For example, in "3d6", the sides is 6.
    /// </summary>
    public Expression Sides => base.Operand2;

    /// <summary>
    /// Returns the result types of the expression.  In this case, the result type is an integer expression since a dice roll will always return an integer value.
    /// </summary>
    public override Type[] ResultTypes => new Type[] { typeof(IntegerExpression) };

    /// <summary>
    /// Compute the result of the dice roll.  This will compute the number of dice to roll and the number of sides on each die, then use the game's random number generator to simulate rolling the dice and summing the results.  The final result is returned as an IntegerExpression.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Returns the text representation of the dice roll expression.  If the number of dice is 1, then the "1" is omitted for brevity.  For example, "d6" is used instead of "1d6".  If the number of dice is not 1, then the full representation is used.  For example, "3d6" is used instead of "d6".
    /// </summary>
    public override string Text
    {
        get
        {
            if (Dice is IntegerExpression integerDiceExpression && integerDiceExpression.Value == 1)
            {
                return $"d{Sides}";
            }
            if (Dice is DecimalExpression decimalDiceExpression && decimalDiceExpression.Value == 1)
            {
                return $"d{Sides}";
            }
            return $"{Dice}d{Sides}";
        }
    }

    /// <summary>
    /// Returns a minimized version of the dice roll expression.  The minimization process performs a minimization on the dice and the sides, and returns a new diceDsides expression.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public override Expression Minimize(MinimizeOptions? options = null)
    {
        Expression minimizedDice = Dice.Minimize(options);
        Expression minimizedSides = Sides.Minimize(options);
        return new DiceRollInfixExpression(Game, minimizedDice, minimizedSides);
    }
}
