namespace AngbandOS.Core.Expressions;

[Serializable]
public class DecimalExpression : Expression
{
    public readonly double Value;
    public DecimalExpression(double value)
    {
        Value = value;
    }

    public override Type[] ResultTypes => new Type[] { typeof(DecimalExpression) };
    public override Expression Compute()
    {
        return this;
    }
    public override string Text => $"{Value}";
}
