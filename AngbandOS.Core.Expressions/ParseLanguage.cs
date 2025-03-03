namespace AngbandOS.Core.Expressions;

[Serializable]
public abstract class ParseLanguage
{
    public virtual string WhitespaceCharacters { get; set; } = " \t";
    public abstract FactorParser[] FactorParsers { get; }
    public virtual (int precedence, InfixOperator infixOperator)[]? InfixOperators => null;
}
