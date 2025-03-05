namespace AngbandOS.Core.Expressions;

[Serializable]
public class BooleanExpression : Expression
{
    public readonly bool Value;
    public BooleanExpression(bool value)
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
