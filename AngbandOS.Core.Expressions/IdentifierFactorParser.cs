namespace AngbandOS.Core.Expressions
{
    public class IdentifierFactorParser : FactorParser
    {
        public readonly (string, bool)[] Identifiers;
        public IdentifierFactorParser(params (string, bool)[] identifiers)
        {
            (string identifier, bool caseSensitive)[] namedIdentifierTuples = identifiers; // This names the tuple elements for the OrderBy.
            Identifiers = namedIdentifierTuples.OrderByDescending(tuple => tuple.identifier.Length).ToArray();
        }

        public override Expression? TryParse(Parser parser, string text, ref int characterIndex)
        {
            int startCharacterIndex = characterIndex;
            char c = text[characterIndex];
            (string identifier, bool caseSensitive)[] identifiers = Identifiers; // This names the tuple elements for the OrderBy.
            foreach ((string identifier, bool caseSensitive) in Identifiers)
            {
                int length = identifier.Length;
                if (startCharacterIndex + length > text.Length)
                {
                    length = text.Length - startCharacterIndex;
                }
                string matchedIdentifier = text.Substring(startCharacterIndex, identifier.Length);
                if (caseSensitive && matchedIdentifier == identifier || !caseSensitive && matchedIdentifier.ToLower() == identifier.ToLower())
                {
                    characterIndex += matchedIdentifier.Length;
                    return new IdentifierExpression(matchedIdentifier);
                }
            }
            return null;
        }
    }
}
