namespace AngbandOS.Core.Expressions;

[Serializable]
public abstract class IdentifierFactorParser : FactorParser
{
    public virtual bool CaseSensitive => false;
    public abstract string Identifier { get; }
    protected abstract Expression GenerateExpression(string matchedIdentifier);
    public override Expression? TryParse(Parser parser, string text, ref int characterIndex)
    {
        int startCharacterIndex = characterIndex;
        char c = text[characterIndex];

        int length = Identifier.Length;
        if (startCharacterIndex + length > text.Length)
        {
            length = text.Length - startCharacterIndex;
        }
        string matchedIdentifier = text.Substring(startCharacterIndex, Identifier.Length);
        if (CaseSensitive && matchedIdentifier == Identifier || !CaseSensitive && matchedIdentifier.ToLower() == Identifier.ToLower())
        {
            characterIndex += matchedIdentifier.Length;
            return GenerateExpression(matchedIdentifier);
        }

        return null;
    }
}
