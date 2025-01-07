namespace AngbandOS.Core.Expressions
{
    public class Parser
    {
        public readonly ParseLanguage ParseLanguage;
        public Parser(ParseLanguage parseLanguage)
        {
            ParseLanguage = parseLanguage;
        }
        public Expression ParseExpression(string text)
        {
            int characterIndex = 0;
            return ParseExpression(text,  0, ref characterIndex);
        }

        public Expression ParseExpression(string text, ref int characterIndex)
        {
            return ParseExpression(text, 0, ref characterIndex);
        }

        private Expression ParseExpression(string text, int precedence, ref int characterIndex)
        {
            IgnoreWhitespace(text, ref characterIndex);
            if (precedence > ParseLanguage.HighestPrecedence)
            {
                if (ParseLanguage.FactorParsers == null)
                {
                    throw new Exception($"Unable to parse expression.  No factor parsers were registered.");
                }
                foreach (FactorParser factorParser in ParseLanguage.FactorParsers)
                {
                    Expression? factorExpression = factorParser.TryParse(this, text, ref characterIndex);
                    if (factorExpression != null)
                    {
                        return factorExpression;
                    }
                }
                throw new Exception($"Unrecognized expression at position {characterIndex} in {text}.");
            }
            else
            {
                Expression expression = ParseExpression(text, precedence + 1, ref characterIndex);

                InfixOperator[]? infixOperators = ParseLanguage.GetPrecedenceOperators(precedence);
                if (infixOperators != null)
                {
                    bool found;
                    do
                    {
                        found = false;
                        foreach (InfixOperator infixOperator in infixOperators)
                        {
                            int length = infixOperator.OperatorSymbol.Length;
                            if (characterIndex + length < text.Length && text.Substring(characterIndex, length) == infixOperator.OperatorSymbol)
                            {
                                characterIndex += length;
                                Expression nextPrecedenceOperator2 = ParseExpression(text, precedence + 1, ref characterIndex);
                                expression = infixOperator.CreateExpression(expression, nextPrecedenceOperator2);
                                found = true;
                                break;
                            }
                        }
                    } while (found);
                }
                return expression;
            }
        }
        private void IgnoreWhitespace(string text, ref int characterIndex)
        {
            while (ParseLanguage.WhitespaceCharacters.Contains(text[characterIndex]))
            {
                characterIndex++;
            }
        }
    }
}
