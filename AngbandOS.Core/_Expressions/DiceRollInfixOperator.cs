namespace AngbandOS.Core.Expressions;

[Serializable]
internal class DiceRollInfixOperator : InfixOperator
{
    public Game Game { get; }
    public DiceRollInfixOperator(Game game)
    {
        Game = game;    
    }
    public override string OperatorSymbol => "d";
    public override InfixExpression CreateExpression(Expression operand1, Expression operand2) => new DiceRollInfixExpression(Game, operand1, operand2);
}
