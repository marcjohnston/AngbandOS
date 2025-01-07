namespace AngbandOS.Core.Expressions
{
    public class AdditionExpression : InfixExpression
    {
        public AdditionExpression(Expression addend1, Expression addend2) : base(addend1, addend2) { }
        public Expression Addend1 => base.Operand1;
        public Expression Addend2 => base.Operand2;
    }
}
