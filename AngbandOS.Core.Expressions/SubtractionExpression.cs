namespace AngbandOS.Core.Expressions
{
    [Serializable]
    public class SubtractionExpression : InfixExpression
    {
        public SubtractionExpression(Expression minuend, Expression subtrahend) : base(minuend, subtrahend) { }
        public Expression Minuend => base.Operand1;
        public Expression Subtrahend => base.Operand2;
        public override Expression Compute()
        {
            Expression minuend = Minuend.Compute();
            Expression subtrahend = Subtrahend.Compute();
            if (minuend is IntegerExpression minuendIntegerExpression && subtrahend is IntegerExpression subtrahendIntegerExpression)
            {
                return new IntegerExpression(minuendIntegerExpression.Value - subtrahendIntegerExpression.Value);
            }
            throw new Exception("Invalid data types for subraction.");
        }
        public override string ToString()
        {
            return $"{Minuend}-{Subtrahend}";
        }
    }
}
