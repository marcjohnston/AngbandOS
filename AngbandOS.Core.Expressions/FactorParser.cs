namespace AngbandOS.Core.Expressions;

[Serializable]
public abstract class FactorParser
{
    /// <summary>
    /// Attempts to parse a factor from the expression text.  If a factor is not 
    /// </summary>
    /// <param name="parser"></param>
    /// <param name="text"></param>
    /// <param name="characterIndex">The index at which to start parsing for the factor and returns the new position after the factor has been accepted.  If a factor is not parse, the position should not be changed.</param>
    /// <returns></returns>
    public abstract Expression? TryParse(ExpressionParser parser, string text, ref int characterIndex);
}
