namespace AngbandOS.Core.Expressions;

[Serializable]
public class IntegerExpression : Expression
{
    public readonly int Value;
    public IntegerExpression(int value)
    {
        Value = value;
    }

    public override Type[] ResultTypes => new Type[] { typeof(IntegerExpression) };
    public override Expression Compute()
    {
        return this;
    }
    public override string Text => $"{Value}";
}
