namespace AngbandOS.Core.Expressions
{
    public class AdditionExpression : InfixExpression
    {
        public AdditionExpression(Expression addend1, Expression addend2) : base(addend1, addend2) { }
        public Expression Addend1 => base.Operand1;
        public Expression Addend2 => base.Operand2;
        public override Expression Compute()
        {
            Expression addend1 = Addend1.Compute();
            Expression addend2 = Addend2.Compute();
            if (addend1 is IntegerExpression addend1IntegerExpression && addend2 is IntegerExpression addend2IntegerExpression)
            {
                return new IntegerExpression(addend1IntegerExpression.Value + addend2IntegerExpression.Value);
            }
            throw new Exception("Invalid data types for addition.");
        }
    }
}
