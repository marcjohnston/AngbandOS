namespace AngbandOS.Core.Expressions;

[Serializable]
public class Parser
{
    public readonly ParseLanguage ParseLanguage;

    /// <summary>
    /// Returns a dictionary of <see cref="InfixOperator"/> objects in an array to optimize the parsing process when the infix operators for a 
    /// specific precedence is requested--the dictionary lookup is O(1) and there is no ToArray().  Also, the return array is presorted in descending
    /// order of symbol length.  The key represents the precedence with a precedence of 0 being the lowest precedence (e.g. addition & subtraction).
    /// </summary>
    private Dictionary<int, InfixOperator[]> OperatorsDictionary = new Dictionary<int, InfixOperator[]>();

    private int HighestPrecedence;

    public Parser(ParseLanguage parseLanguage)
    {
        ParseLanguage = parseLanguage;
        if (ParseLanguage.InfixOperators != null)
        {
            foreach ((int precedence, InfixOperator infixOperator) in ParseLanguage.InfixOperators)
            {
                if (OperatorsDictionary.TryGetValue(precedence, out InfixOperator[]? infixOperators))
                {
                    // Ensure there is no ambigious operators (duplicates).
                    if (infixOperators.Any(_infixOperator => _infixOperator.OperatorSymbol == infixOperator.OperatorSymbol))
                    {
                        throw new Exception($"Cannot register ambigious infix operator {infixOperator.OperatorSymbol}");
                    }

                    // Add an additional operator to the precedence list and sort by length descending.
                    List<InfixOperator> operatorsList = infixOperators.ToList();
                    operatorsList.Add(infixOperator);
                    OperatorsDictionary[precedence] = operatorsList.OrderByDescending(_infixOperator => _infixOperator.OperatorSymbol.Length).ToArray();
                }
                else
                {
                    // Add the first operator.
                    OperatorsDictionary.Add(precedence, new InfixOperator[] { infixOperator });
                }

                if (precedence > HighestPrecedence)
                {
                    HighestPrecedence = precedence;
                }
            }
        }
    }

    /// <summary>
    /// Parses a complete expression and returns an <see cref="Expression"/> equivalent.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public Expression ParseExpression(string text)
    {
        int characterIndex = 0;
        Expression expression = ParseExpression(text,  0, ref characterIndex);
        IgnoreWhitespace(text, ref characterIndex);
        if (characterIndex != text.Length)
        {
            throw new Exception($"Invalid expression {text} at index {characterIndex}.");
        }
        return expression;
    }

    /// <summary>
    /// Parses a nested expression from the position indicated by <paramref name="characterIndex"/>.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="characterIndex"></param>
    /// <returns></returns>
    public Expression ParseExpression(string text, ref int characterIndex)
    {
        return ParseExpression(text, 0, ref characterIndex);
    }

    private Expression ParseExpression(string text, int precedence, ref int characterIndex)
    {
        IgnoreWhitespace(text, ref characterIndex);
        if (precedence > HighestPrecedence)
        {
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

            IgnoreWhitespace(text, ref characterIndex);

            // Retrieve the infix operators for this level of precedence.
            if (OperatorsDictionary.TryGetValue(precedence, out InfixOperator[]? infixOperators))
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
        while (characterIndex < text.Length && ParseLanguage.WhitespaceCharacters.Contains(text[characterIndex]))
        {
            characterIndex++;
        }
    }
}
