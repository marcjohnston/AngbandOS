namespace AngbandOS.Core.Expressions
{
    [Serializable]
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
        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
