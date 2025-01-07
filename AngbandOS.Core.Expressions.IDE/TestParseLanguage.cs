// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Expressions.IDE;

public class TestParseLanguage : ParseLanguage
{
    public override string WhitespaceCharacters => " ";
    public override FactorParser[] FactorParsers => new FactorParser[]
    {
        new ParenthesisFactorParser(),
        new IntegerFactorParser(),
        new IdentifierFactorParser("x", false, () =>
        {
            InputForm inputForm = new InputForm();
            //inputForm.la
            //inputForm.ShowDialog();
            if (inputForm.ShowDialog() != DialogResult.OK)
            {
                throw new Exception("Input cancelled.");
            }
            string text = inputForm.TextInput;
            if (!Int32.TryParse(text, out int value))
            {
                throw new Exception("Invalid integer.");
            }
            return new IntegerExpression(value);
        })
    };
    public override (int, InfixOperator)[]? InfixOperators => new (int, InfixOperator)[]
    {
        (0, new AdditionInfixOperator()),
        (0, new SubtractionInfixOperator()),
        (1, new MultiplicationInfixOperator()),
        (1, new DivisionInfixOperator()),
        (2, new DiceRollInfixOperator())
    };
}