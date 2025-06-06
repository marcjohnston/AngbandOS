namespace AngbandOS.Core.Expressions;

[Serializable]
public class BooleanExpression : Expression
{
    public readonly bool Value;
    public BooleanExpression(bool value)
    {
        Value = value;
    }

    public override Type[] ResultTypes => new Type[] { typeof(BooleanExpression) };
    public override Expression Compute()
    {
        return this;
    }
    public override string Text => $"{Value}";
}
