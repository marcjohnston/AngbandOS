namespace AngbandOS.Core.Expressions
{
    public class Parser
    {
        public readonly SymbolSet Digits = new SymbolSet("0123456789");
        public Expression ParseExpression(string text, ParseLanguage parseLanguage)
        {
            int characterIndex = 0;
            return ParseExpression(text, parseLanguage, ref characterIndex);
        }

        public Expression ParseExpression(string text, ParseLanguage parseLanguage, ref int characterIndex)
        {
            return ParseSimpleExpression(text, parseLanguage, ref characterIndex);
        }
        private Expression ParseSimpleExpression(string text, ParseLanguage parseLanguage, ref int characterIndex)
        {
            IgnoreWhitespace(text, parseLanguage, ref characterIndex);
            Expression term = ParseTerm(text, parseLanguage, ref characterIndex);
            char peekChar = text[characterIndex];
            if (peekChar == '+')
            {
                characterIndex++;
                Expression term2 = ParseTerm(text, parseLanguage, ref characterIndex);
                return new AdditionExpression(term, term2);
            }
            else if (peekChar == '-')
            {
                characterIndex++;
                Expression term2 = ParseTerm(text, parseLanguage, ref characterIndex);
                return new SubtractionExpression(term, term2);
            }
            return term;
        }
        private Expression ParseTerm(string text, ParseLanguage parseLanguage, ref int characterIndex)
        {
            IgnoreWhitespace(text, parseLanguage, ref characterIndex);
            Expression exponent = ParseExponent(text, parseLanguage, ref characterIndex);
            do
            {
                if (characterIndex >= text.Length)
                {
                    break;
                }
                char peekChar = text[characterIndex];
                if (peekChar == '*')
                {
                    characterIndex++;
                    Expression exponent2 = ParseExponent(text, parseLanguage, ref characterIndex);
                    exponent = new MultiplicationExpression(exponent, exponent2);
                }
                else if (peekChar == '/')
                {
                    characterIndex++;
                    Expression exponent2 = ParseExponent(text, parseLanguage, ref characterIndex);
                    exponent = new DivisionExpression(exponent, exponent2);
                }
                else
                {
                    break;
                }
            } while (true);
            return exponent;
        }
        private Expression ParseExponent(string text, ParseLanguage parseLanguage, ref int characterIndex)
        {
            IgnoreWhitespace(text, parseLanguage, ref characterIndex);
            Expression factor = ParseFactor(text, parseLanguage, ref characterIndex);
            if (characterIndex < text.Length)
            {
                char peekChar = text[characterIndex];
                if (peekChar == 'd')
                {
                    characterIndex++;
                    Expression factor2 = ParseFactor(text, parseLanguage, ref characterIndex);
                    return new DiceRollExpression(factor, factor2);
                }
            }
            return factor;
        }
        private Expression ParseFactor(string text, ParseLanguage parseLanguage, ref int characterIndex)
        {
            IgnoreWhitespace(text, parseLanguage, ref characterIndex);
            int startCharacterIndex = characterIndex;
            char c = text[characterIndex];
            if (c == '(') {
                characterIndex++;
                Expression parenthesisExpression = ParseExpression(text, parseLanguage, ref characterIndex);
                if (text[characterIndex] != ')')
                {
                    throw new Exception($"Missing closing parenthesis in expression \"{text}\" at position {characterIndex}.");
                }
                characterIndex++;
                return parenthesisExpression;
            }
            else if (Digits.Contains(c))
            {
                characterIndex++;
                while (text.Length > characterIndex && Digits.Contains(text[characterIndex]))
                {
                    characterIndex++;
                }
                string integerText = text.Substring(startCharacterIndex, characterIndex - startCharacterIndex);
                if (!Int32.TryParse(integerText, out int integerValue))
                {
                    throw new Exception($"Invalid int32 value in expression \"{text}\" at position {characterIndex}.");
                }
                return new IntegerExpression(integerValue);
            }
            else
            {
                (string identifier, bool caseSensitive)[] identifiers = parseLanguage.ValidIdentifiers; // This names the tuple elements for the OrderBy.
                foreach ((string identifier, bool caseSensitive) in identifiers.OrderByDescending(tuple => tuple.identifier.Length))
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
            }
            throw new Exception($"Unrecognized factor in expression \"{text}\" at position {characterIndex}.");
        }

        private void IgnoreWhitespace(string text, ParseLanguage parseLanguage, ref int characterIndex)
        {
            while (parseLanguage.WhitespaceCharacters.Contains(text[characterIndex]))
            {
                characterIndex++;
            }
        }
    }
}
