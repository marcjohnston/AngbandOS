namespace AngbandOS.Core.Expressions
{
    public class AdditionExpression : Expression
    {
        public readonly Expression Addend1;
        public readonly Expression Addend2;
        public AdditionExpression(Expression addend1, Expression addend2)
        {
            Addend1 = addend1;
            Addend2 = addend2;
        }
    }
}
