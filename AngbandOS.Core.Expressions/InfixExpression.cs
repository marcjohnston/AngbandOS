namespace AngbandOS.Core.Expressions;

[Serializable]
public abstract class InfixExpression : Expression
{
    protected readonly Expression Operand1;
    protected readonly Expression Operand2;
    public InfixExpression(Expression operand1, Expression operand2)
    {
        Operand1 = operand1;
        Operand2 = operand2;
    }
}
