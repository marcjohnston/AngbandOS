namespace AngbandOS.Core.Expressions;

[Serializable]
internal class DiceRollInfixOperator : InfixOperator
{
    public readonly Game Game;
    public DiceRollInfixOperator(Game game)
    {
        Game = game;    
    }
    public override string OperatorSymbol => "d";
    public override InfixExpression CreateExpression(Expression operand1, Expression operand2) => new DiceRollExpression(Game, operand1, operand2);
}
