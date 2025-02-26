namespace AngbandOS.Core.Expressions
{
    [Serializable]
    public abstract class FactorParser
    {
        public abstract Expression? TryParse(Parser parser, string text, ref int characterIndex);
    }
}
