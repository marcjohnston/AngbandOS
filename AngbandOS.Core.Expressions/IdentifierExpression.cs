namespace AngbandOS.Core.Expressions
{
    public class IdentifierExpression : Expression
    {
        public readonly string Identifier;
        public readonly Func<Expression> GetValueFunction;
        public IdentifierExpression(string identifier, Func<Expression> getValueFunction)
        {
            Identifier = identifier;
            GetValueFunction = getValueFunction;
        }
        public override Expression Compute()
        {
            return GetValueFunction();
        }
        public override string ToString()
        {
            return $"{Identifier}";
        }
    }
}
