namespace AngbandOS.Core.Expressions;

internal class BonusInfixExpression : InfixExpression
{
    /// <summary>
    /// Returns the game object.  This is needed for access to the Random to compute the dice roll.
    /// </summary>
    public BonusInfixExpression(Expression dice, Expression sides) : base(dice, sides) { }

    /// <summary>
    /// The number of dice to roll.  This is the left operand of the infix operator.  For example, in "3d6", the dice is 3.  In "d6", the dice is 1.
    /// </summary>
    public Expression MaxValue => base.Operand1;

    /// <summary>
    /// The number of sides on each die.  This is the right operand of the infix operator.  For example, in "3d6", the sides is 6.
    /// </summary>
    public Expression MaxDepth => base.Operand2;

    /// <summary>
    /// Returns the result types of the expression.  In this case, the result type is an integer expression since a dice roll will always return an integer value.
    /// </summary>
    public override Type[] ResultTypes => new Type[] { typeof(IntegerExpression) };

    /// <summary>
    /// Compute the result of the dice roll.  This will compute the number of dice to roll and the number of sides on each die, then use the game's random number generator to simulate rolling the dice and summing the results.  The final result is returned as an IntegerExpression.
    /// </summary>
    /// <returns></returns>
    public override Expression Compute(Dictionary<string, object> providers)
    {
        // Compute the dice and sides expressions to get the number of dice and the number of sides on each die.
        Expression maxValueExpression = MaxValue.Compute(providers);
        Expression maxDepthExpression = MaxDepth.Compute(providers);

        // Validate that both expressions compute to IntegerExpressions, since the number of dice and the number of sides must be integers.  If either expression does not compute to an IntegerExpression, throw an exception with a descriptive error message indicating which expression is invalid and what type it computed to.
        if (maxValueExpression is not IntegerExpression maxValueIntegerExpression)
        {
            throw new ArgumentException($"The max-value expression must compute to an IntegerExpression.  The current type is {maxValueExpression.GetType().Name}.");
        }
        if (maxDepthExpression is not IntegerExpression maxDepthIntegerExpression)
        {
            throw new ArgumentException($"The max-depth expression must compute to an IntegerExpression.  The current type is {maxDepthExpression.GetType().Name}.");
        }

        // Retrieve the Random from the dependencies dictionary.  If the Random is not present in the dependencies, throw an exception with a descriptive error message indicating that the Random is required to compute the dice roll.
        GameRandom random = (GameRandom)providers[nameof(ExpressionProvidersEnum.Random)];
        Func<int> getExperienceLevel = (Func<int>)providers[nameof(ExpressionProvidersEnum.GetExperienceLevel)];
        int experienceLevel = getExperienceLevel();

        // Compute the roll.  This is done by rolling the specified number of dice, where each die has the specified number of sides.  The result of each die roll is a random integer between 1 and the number of sides (inclusive).  The total result is the sum of all the individual die rolls.  For example, if the expression is "3d6", then we would roll three six-sided dice, and the result would be the sum of those three rolls, which could be anywhere from 3 to 18.
        int bonusValue = Game.GetBonusValue(random, maxValueIntegerExpression.Value, experienceLevel, maxDepthIntegerExpression.Value);
        return new IntegerExpression(bonusValue);
    }

    /// <summary>
    /// Returns the text representation of the dice roll expression.  If the number of dice is 1, then the "1" is omitted for brevity.  For example, "d6" is used instead of "1d6".  If the number of dice is not 1, then the full representation is used.  For example, "3d6" is used instead of "d6".
    /// </summary>
    public override string Text
    {
        get
        {
            if (MaxValue is IntegerExpression integerDiceExpression && integerDiceExpression.Value == 1)
            {
                return $"b{MaxDepth}";
            }
            if (MaxValue is DecimalExpression decimalDiceExpression && decimalDiceExpression.Value == 1)
            {
                return $"b{MaxDepth}";
            }
            return $"{MaxValue}b{MaxDepth}";
        }
    }

    /// <summary>
    /// Returns a minimized version of the dice roll expression.  The minimization process performs a minimization on the dice and the sides, and returns a new diceDsides expression.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public override Expression Minimize(Dictionary<string, object> providers, MinimizeOptions? options = null)
    {
        Expression minimizedDice = MaxValue.Minimize(providers, options);
        Expression minimizedSides = MaxDepth.Minimize(providers, options);

        // There is no minimized form of a bonus expression.
        return new BonusInfixExpression(minimizedDice, minimizedSides);
    }
}
