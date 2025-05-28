using System.Windows.Markup;

namespace AngbandOS.Core.Expressions;

[Serializable]
public class ParenthesisFactorParser : FactorParser
{

    public override Expression? TryParse(ExpressionParser parser, string text, ref int characterIndex)
    {
        int currentCharacterIndex = characterIndex;
        bool? sign = null;
        if (text[currentCharacterIndex] == '-')
        {
            sign = false;
            currentCharacterIndex++;
        }
        else if (text[currentCharacterIndex] == '+')
        {
            sign = true;
            currentCharacterIndex++;
        }
        if (text[currentCharacterIndex] == '(')
        {
            currentCharacterIndex++;
            Expression parenthesisExpression = parser.ParseExpression(text, ref currentCharacterIndex);
            if (text[currentCharacterIndex] != ')')
            {
                throw new Exception($"Missing closing parenthesis in expression \"{text}\" at position {characterIndex}.");
            }
            currentCharacterIndex++;
            characterIndex = currentCharacterIndex;
            return new ParenthesisExpression(parenthesisExpression, sign);
        }
        return null;
    }
}
