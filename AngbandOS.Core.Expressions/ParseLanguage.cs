namespace AngbandOS.Core.Expressions
{
    public class ParseLanguage
    {
        public string WhitespaceCharacters = " \t";

        /// <summary>
        /// Returns a dictionary of <see cref="InfixOperator"/> objects in an array to optimize the parsing process when the infix operators for a 
        /// specific precedence is requested--the dictionary lookup is O(1) and there is no ToArray().  Also, the return array is presorted in descending
        /// order of symbol length.  The key represents the precedence with a precedence of 0 being the lowest precedence (e.g. addition & subtraction).
        /// </summary>
        private Dictionary<int, InfixOperator[]> OperatorsDictionary = new Dictionary<int, InfixOperator[]>();
        public FactorParser[]? FactorParsers { get; private set; } = null;
        public int HighestPrecedence { get; private set; }

        public InfixOperator[]? GetPrecedenceOperators(int precedence)
        {
            if (!OperatorsDictionary.TryGetValue(precedence, out InfixOperator[]? operators))
            {
                return null;
            }
            return operators;
        }
        public void RegisterInfixOperator(int precedence, InfixOperator infixOperator)
        {
            if (OperatorsDictionary.TryGetValue(precedence, out InfixOperator[]? infixOperators))
            {
                // Ensure there is no ambigious operators (duplicates).
                if (infixOperators.Any(_infixOperator => _infixOperator.OperatorSymbol == infixOperator.OperatorSymbol))
                {
                    throw new Exception($"Cannot register Ambigious infix operator {infixOperator.OperatorSymbol}");
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

        public void RegisterFactorParser(FactorParser factorParser)
        {
            if (FactorParsers == null)
            {
                // Add the first factor parser.
                FactorParsers = new FactorParser[] { factorParser };
            }
            else
            {
                List<FactorParser> factorParsersList = FactorParsers.ToList();
                factorParsersList.Add(factorParser);
                FactorParsers = factorParsersList.ToArray();
            }
        }
    }
}
