namespace AngbandOS.Core.Expressions
{
    [Serializable]
    public class DivisionExpression : InfixExpression
    {
        public DivisionExpression(Expression dividend, Expression divisor) : base(dividend, divisor) { }
        public Expression Dividend => base.Operand1;
        public Expression Divisor => base.Operand2;
        public override Expression Compute()
        {
            Expression dividend = Dividend.Compute();
            Expression divisor = Divisor.Compute();
            if (dividend is IntegerExpression dividendIntegerExpression && divisor is IntegerExpression divisorIntegerExpression)
            {
                if (divisorIntegerExpression.Value == 0)
                {
                    throw new Exception("Divide by zero error.");
                }
                return new IntegerExpression(dividendIntegerExpression.Value / divisorIntegerExpression.Value);
            }
            throw new Exception("Invalid data types for division.");
        }
        public override string ToString()
        {
            return $"{Dividend}/{Divisor}";
        }
    }
}
