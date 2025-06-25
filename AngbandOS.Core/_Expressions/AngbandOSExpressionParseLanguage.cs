// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Expressions;

[Serializable]
internal class AngbandOSExpressionParseLanguage : ParseLanguage
{
    public readonly Game Game;
    
    public AngbandOSExpressionParseLanguage(Game game)
    {
        Game = game;
    }
    public override string WhitespaceCharacters => " ";
    public override FactorParser[] FactorParsers => new FactorParser[]
    {
        new ParenthesisFactorParser(),
        new BooleanFactorParser(),
        new DecimalFactorParser(), // A decimal value needs to be parsed before an integer attempt is made.
        new IntegerFactorParser(),
        new ExperienceLevelIdentifierFactorParser(Game),
        new DifficultyIdentifierFactorParser(Game),
        new HealthIdentifierFactorParser(Game)
    };

    public override (int, InfixOperator)[]? InfixOperators => new (int, InfixOperator)[]
    {
        (0, new EqualsInfixOperator()),
        (1, new AdditionInfixOperator()),
        (1, new SubtractionInfixOperator()),
        (2, new MultiplicationInfixOperator()),
        (2, new DivisionInfixOperator()),
        (3, new DiceRollInfixOperator(Game)) // This is the most significant operation
    };
}
