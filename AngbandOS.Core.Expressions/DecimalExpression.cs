namespace AngbandOS.Core.Expressions;

[Serializable]
public class DecimalExpression : Expression
{
    public readonly double Value;
    public DecimalExpression(double value)
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
