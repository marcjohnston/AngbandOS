namespace AngbandOS.Core.Expressions;

public class BooleanExpression : Expression
{
    public readonly bool Value;
    public BooleanExpression(bool value)
    {
        Value = value;
    }

    public override Type[] ResultTypes => new Type[] { typeof(BooleanExpression) };
    public override Expression Compute(Dictionary<string, object> providers) => this;
    public override string Text => $"{Value}";
}
