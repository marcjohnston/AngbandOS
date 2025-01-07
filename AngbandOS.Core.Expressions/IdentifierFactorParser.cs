namespace AngbandOS.Core.Expressions
{
    public class IdentifierFactorParser : FactorParser
    {
        public bool CaseSensitive { get; }
        public string Identifier { get; }
        public IdentifierFactorParser(string identifier, bool caseSensitive)
        {
            CaseSensitive = caseSensitive;
            Identifier = identifier;
        }

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
                return new IdentifierExpression(matchedIdentifier);
            }

            return null;
        }
    }
}
