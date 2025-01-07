namespace AngbandOS.Core.Expressions
{
    public class IntegerExpression : Expression
    {
        public readonly int Value;
        public IntegerExpression(int value)
        {
            Value = value;
        }

        public override Expression Compute()
        {
            return this;
        }
    }
}
