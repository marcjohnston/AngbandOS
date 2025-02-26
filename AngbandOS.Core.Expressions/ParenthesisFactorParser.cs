namespace AngbandOS.Core.Expressions
{
    [Serializable]
    public class ParenthesisFactorParser : FactorParser
    {

        public override Expression? TryParse(Parser parser, string text, ref int characterIndex)
        {
            if (text[characterIndex] == '(')
            {
                characterIndex++;
                Expression parenthesisExpression = parser.ParseExpression(text, ref characterIndex);
                if (text[characterIndex] != ')')
                {
                    throw new Exception($"Missing closing parenthesis in expression \"{text}\" at position {characterIndex}.");
                }
                characterIndex++;
                return parenthesisExpression;
            }
            return null;
        }
    }
}
