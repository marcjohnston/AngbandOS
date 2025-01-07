namespace AngbandOS.Core.Expressions
{
    public abstract class FactorParser
    {
        public abstract Expression? TryParse(Parser parser, string text, ref int characterIndex);
    }
}
