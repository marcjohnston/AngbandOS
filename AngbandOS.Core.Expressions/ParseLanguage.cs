namespace AngbandOS.Core.Expressions;

[Serializable]
public abstract class ParseLanguage
{
    private readonly Dictionary<string, ExpressionTypeConverter> TypeConverterDictionary = new Dictionary<string, ExpressionTypeConverter>();

    protected ParseLanguage()
    {
        if (TypeConverters != null)
        {
            foreach (ExpressionTypeConverter expressionTypeConverter in TypeConverters)
            {
                string key = GenerateTypeConverterKey(expressionTypeConverter.FromExpressionType.Name, expressionTypeConverter.ToExpressionType.Name);
                TypeConverterDictionary.Add(key, expressionTypeConverter);
            }
        }
    }

    private string GenerateTypeConverterKey(string fromExpressionTypeName, string toExpressionTypeName)
    {
        return $"{fromExpressionTypeName}-{toExpressionTypeName}";
    }

    public ExpressionTypeConverter? GetTypeConverter<TDesiredExpression>(Expression fromExpression)
    {
        string key = GenerateTypeConverterKey(fromExpression.GetType().Name, typeof(TDesiredExpression).Name);
        TypeConverterDictionary.TryGetValue(key, out ExpressionTypeConverter? typeConverter);
        return typeConverter;
    }

    public TExpression? ConvertTo<TExpression>(Expression expression) where TExpression : Expression
    {
        if (expression is TExpression)
        {
            return (TExpression)expression;
        }
        ExpressionTypeConverter? typeConverter = GetTypeConverter<TExpression>(expression);
        if (typeConverter == null)
        {
            return null;
        }
        return (TExpression)typeConverter.Convert(expression);
    }

    /// <summary>
    /// Returns the characters that should be recognized as whitespace.
    /// </summary>
    public virtual string WhitespaceCharacters { get; set; } = " \t";

    /// <summary>
    /// Returns the factor parsers that should be used to attempt to parse the factors.  Factors are parsed in order from first to last.  This order of precedence may affect recognition of
    /// factors that are subsets of other factors.  For example: parsing a decimal factor would need to be attempted before parsing an integer factor; otherwise the integer parser would take
    /// the whole value as valid and leave a decimal part which may be recognized as a valid decimal (with no leading 0); resulting in decimal representation returning an integer and a decimal 
    /// factor instead of a single decimal factor.
    /// </summary>
    public abstract FactorParser[] FactorParsers { get; }

    /// <summary>
    /// Returns the infix operators that should be recognized.  The higher value precedence values are considered more significant.  Example: exponents should have a higher precedence over addition
    /// and multiplication.  Multiplication should have a high precedence over addition and subtraction.  The first precedence should be zero.  Skipping precedence values (including zero) should 
    /// not affect parsing but will affect performance; therefore, skipping precedence values is undesireable.
    /// </summary>
    public virtual (int precedence, InfixOperator infixOperator)[]? InfixOperators => null;

    public virtual ExpressionTypeConverter[]? TypeConverters => null;
}
