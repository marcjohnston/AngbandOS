namespace AngbandOS.Core.Expressions
{
    public class IdentifierExpression : Expression
    {
        public readonly string Identifier;
        public IdentifierExpression(string identifier)
        {
            Identifier = identifier;
        }
    }
}
