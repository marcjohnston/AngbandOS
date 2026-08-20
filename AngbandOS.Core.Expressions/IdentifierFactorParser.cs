namespace AngbandOS.Core.Expressions;

public abstract class IdentifierFactorParser : FactorParser
{
    public virtual bool CaseSensitive => false;
    public abstract string Identifier { get; }
    protected abstract Expression GenerateExpression(string matchedIdentifier, bool? sign);
    public override Expression? TryParse(ExpressionParser parser, string text, ref int characterIndex)
    {
        int currentCharacterIndex = characterIndex;

        // Check for a sign before the identifier.
        bool? sign = null;
        if (text[currentCharacterIndex] == '+')
        {
            sign = true;
            currentCharacterIndex++;
        }
        else if (text[currentCharacterIndex] == '-')
        {
            sign = false;
            currentCharacterIndex++;
        }

        if (sign.HasValue)
        {
            parser.IgnoreWhitespace(text, ref currentCharacterIndex);
        }

        // Check to see if there is enough length for a match.
        if (currentCharacterIndex + Identifier.Length > text.Length)
        {
            return null;
        }

        string matchedIdentifier = text.Substring(currentCharacterIndex, Identifier.Length);
        if (CaseSensitive && matchedIdentifier == Identifier || !CaseSensitive && matchedIdentifier.ToLower() == Identifier.ToLower())
        {
            characterIndex = currentCharacterIndex + matchedIdentifier.Length;
            return GenerateExpression(matchedIdentifier, sign);
        }

        return null;
    }
}
